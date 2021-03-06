﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;
using Util.MyMath;

namespace Spatial
{
  public class KdTreeObject
  {
    public ISpaceObject SpaceObject;
    public Vector3 Position;
    public float Radius;
    public Vector3 Velocity;
    public bool IsAvoidable;

    internal float MaxX;
    internal float MinX;
    internal float MaxZ;
    internal float MinZ;
    internal bool Indexed;

    public KdTreeObject(ISpaceObject obj)
    {
      CopyFrom(obj);
    }
    public void CopyFrom(ISpaceObject obj)
    {
      if (null != obj) {
        SpaceObject = obj;
        Position = obj.GetPosition();
        Radius = (float)obj.GetRadius();
        Velocity = obj.GetVelocity();
        IsAvoidable = obj.IsAvoidable();
        MaxX = Position.x + Radius;
        MinX = Position.x - Radius;
        MaxZ = Position.z + Radius;
        MinZ = Position.z - Radius;
        Indexed = false;
      } else {
        SpaceObject = null;
        Position = new Vector3();
        Radius = 0;
        Velocity = new Vector3();
        IsAvoidable = false;
        MaxX = MinX = 0;
        MaxZ = MinZ = 0;
        Indexed = false;
      }
    }
  }
  public sealed class KdObjectTree
  {
    public const int c_MaxLeafSize = 4;

    private struct KdTreeNode
    {
      internal int m_Begin;
      internal int m_End;
      internal int m_Left;
      internal int m_Right;
      internal float m_MaxX;
      internal float m_MaxZ;
      internal float m_MinX;
      internal float m_MinZ;
    }

    public void Build(IList<ISpaceObject> objs)
    {
      if (null == m_Objects || m_Objects.Length < objs.Count) {
        m_ObjectNum = 0;
        m_Objects = new KdTreeObject[objs.Count * 2];
        foreach (ISpaceObject obj in objs) {
          m_Objects[m_ObjectNum++] = new KdTreeObject(obj);
        }
      } else {
        m_ObjectNum = 0;
        foreach (ISpaceObject obj in objs) {
          if (null == m_Objects[m_ObjectNum])
            m_Objects[m_ObjectNum] = new KdTreeObject(obj);
          else
            m_Objects[m_ObjectNum].CopyFrom(obj);
          ++m_ObjectNum;
        }
      }
      if (m_ObjectNum > 0) {
        if (null == m_KdTree || m_KdTree.Length < 3 * m_ObjectNum) {
          m_KdTree = new KdTreeNode[3 * m_ObjectNum];
          for (int i = 0; i < m_KdTree.Length; ++i) {
            m_KdTree[i] = new KdTreeNode();
          }
        }
        m_MaxNodeNum = 2 * m_ObjectNum;
        BuildImpl();
      }
    }
    public void Clear()
    {
      m_ObjectNum = 0;
    }

    public void Query(ISpaceObject obj, float range, MyAction<float, KdTreeObject> visitor)
    {
      Query(obj.GetPosition(), range, visitor);
    }

    public void Query(Vector3 pos, float range, MyAction<float, KdTreeObject> visitor)
    {
      if (null != m_KdTree && m_ObjectNum > 0 && m_KdTree.Length > 0) {
        float rangeSq = Sqr(range);
        QueryImpl(pos, range, rangeSq, (float distSqr, KdTreeObject obj) => { visitor(distSqr, obj); return true; });
      }
    }

    public void Query(ISpaceObject obj, float range, MyFunc<float, KdTreeObject, bool> visitor)
    {
      Query(obj.GetPosition(), range, visitor);
    }

    public void Query(Vector3 pos, float range, MyFunc<float, KdTreeObject, bool> visitor)
    {
      if (null != m_KdTree && m_ObjectNum > 0 && m_KdTree.Length > 0) {
        float rangeSq = Sqr(range);
        QueryImpl(pos, range, rangeSq, visitor);
      }
    }

    public void VisitTree(MyAction<float, float, float, float, int, int, KdTreeObject[]> visitor)
    {
      VisitTree((float minx, float minz, float maxx, float maxz, int begin, int end, KdTreeObject[] objs) => { visitor(minx, minz, maxx, maxz, begin, end, objs); return true; });
    }

    public void VisitTree(MyFunc<float, float, float, float, int, int, KdTreeObject[], bool> visitor)
    {
      if (null != m_KdTree && m_ObjectNum > 0 && m_KdTree.Length > 0) {
        VisitTreeImpl(visitor);
      }
    }

    private void BuildImpl()
    {
      int nextUnusedNode = 1;
      m_BuildStack.Push(0);
      m_BuildStack.Push(m_ObjectNum);
      m_BuildStack.Push(0);
      while(m_BuildStack.Count>=3) {
        int begin = m_BuildStack.Pop();
        int end = m_BuildStack.Pop();
        int node = m_BuildStack.Pop();

        KdTreeObject obj0 = m_Objects[begin];
        float minX = obj0.MinX;
        float maxX = obj0.MaxX;
        float minZ = obj0.MinZ;
        float maxZ = obj0.MaxZ;
        for (int i = begin + 1; i < end; ++i) {
          KdTreeObject obj = m_Objects[i];
          float newMaxX = obj.MaxX;
          float newMinX = obj.MinX;
          float newMaxZ = obj.MaxZ;
          float newMinZ = obj.MinZ;
          if (minX > newMinX) minX = newMinX;
          if (maxX < newMaxX) maxX = newMaxX;
          if (minZ > newMinZ) minZ = newMinZ;
          if (maxZ < newMaxZ) maxZ = newMaxZ;
        }
        m_KdTree[node].m_MinX = minX;
        m_KdTree[node].m_MaxX = maxX;
        m_KdTree[node].m_MinZ = minZ;
        m_KdTree[node].m_MaxZ = maxZ;

        if (end - begin > c_MaxLeafSize) {

          m_KdTree[node].m_Left = nextUnusedNode;
          ++nextUnusedNode;
          m_KdTree[node].m_Right = nextUnusedNode;
          ++nextUnusedNode;

          bool isVertical = (maxX - minX > maxZ - minZ);
          float splitValue = (isVertical ? 0.5f * (maxX + minX) : 0.5f * (maxZ + minZ));

          int begin0 = begin;
          int left = begin;
          int right = end;

          bool canSplit = false;
          while (left < right) {
            while (left < right) {
              KdTreeObject obj = m_Objects[left];
              if ((isVertical ? obj.MaxX : obj.MaxZ) < splitValue) {
                ++left;
                canSplit = true;
              } else if ((isVertical ? obj.MinX : obj.MinZ) < splitValue) {
                obj.Indexed = true;
                break;
              } else {
                break;
              }
            }
            while (left < right) {
              KdTreeObject obj = m_Objects[right - 1];
              if ((isVertical ? obj.MinX : obj.MinZ) >= splitValue) {
                --right;
              } else if ((isVertical ? obj.MaxX : obj.MaxZ) >= splitValue) {
                obj.Indexed = true;
                break;
              } else {
                break;
              }
            }

            if (left < right) {
              if (m_Objects[left].Indexed || m_Objects[right - 1].Indexed) {
                if (m_Objects[left].Indexed) {
                  KdTreeObject tmp = m_Objects[begin];
                  m_Objects[begin] = m_Objects[left];
                  m_Objects[left] = tmp;
                  ++begin;
                  ++left;
                  canSplit = true;
                }
                if (left < right && m_Objects[right - 1].Indexed) {
                  KdTreeObject tmp = m_Objects[begin];
                  m_Objects[begin] = m_Objects[right - 1];
                  m_Objects[right - 1] = tmp;
                  ++begin;
                  if (begin >= left) {
                    ++left;
                    canSplit = true;
                  }
                }
              } else {
                KdTreeObject tmp = m_Objects[left];
                m_Objects[left] = m_Objects[right - 1];
                m_Objects[right - 1] = tmp;
                ++left;
                --right;
                canSplit = true;
              }
            }
          }

          if (canSplit) {
            m_KdTree[node].m_Begin = begin0;
            m_KdTree[node].m_End = begin;

            if (left > begin) {
              m_BuildStack.Push(m_KdTree[node].m_Left);
              m_BuildStack.Push(left);
              m_BuildStack.Push(begin);
            }

            if (end > left) {
              m_BuildStack.Push(m_KdTree[node].m_Right);
              m_BuildStack.Push(end);
              m_BuildStack.Push(left);
            }
          } else {
            m_KdTree[node].m_Begin = begin0;
            m_KdTree[node].m_End = begin0;
            m_KdTree[node].m_Left = 0;
            m_KdTree[node].m_Right = 0;
            nextUnusedNode -= 2;
          }
        } else {
          m_KdTree[node].m_Begin = begin;
          m_KdTree[node].m_End = end;
          m_KdTree[node].m_Left = 0;
          m_KdTree[node].m_Right = 0;
        }
      }
    }

    private void QueryImpl(Vector3 pos, float range, float rangeSq, MyFunc<float, KdTreeObject, bool> visitor)
    {
      m_QueryStack.Push(0);
      while (m_QueryStack.Count > 0) {
        int node = m_QueryStack.Pop();
        int begin = m_KdTree[node].m_Begin;
        int end = m_KdTree[node].m_End;
        int left = m_KdTree[node].m_Left;
        int right = m_KdTree[node].m_Right;

        if (end > begin) {
          for (int i = begin; i < end; ++i) {
            KdTreeObject obj = m_Objects[i];
            if (Geometry.RectangleOverlapRectangle(pos.x - range, pos.z - range, pos.x + range, pos.z + range, obj.MinX, obj.MinZ, obj.MaxX, obj.MaxZ)) {
              float distSq = Geometry.DistanceSquare(pos, obj.Position);
              if (!visitor(distSq, obj)) {
                m_QueryStack.Clear();
                return;
              }
            }
          }
        }

        float minX = m_KdTree[node].m_MinX;
        float minZ = m_KdTree[node].m_MinZ;
        float maxX = m_KdTree[node].m_MaxX;
        float maxZ = m_KdTree[node].m_MaxZ;

        bool isVertical = (maxX - minX > maxZ - minZ);
        float splitValue = (isVertical ? 0.5f * (maxX + minX) : 0.5f * (maxZ + minZ));

        if ((isVertical ? pos.x + range : pos.z + range) < splitValue) {
          if (left > 0)
            m_QueryStack.Push(left);
        } else if ((isVertical ? pos.x - range : pos.z - range) < splitValue) {
          if (left > 0)
            m_QueryStack.Push(left);
          if (right > 0)
            m_QueryStack.Push(right);
        } else {
          if (right > 0)
            m_QueryStack.Push(right);
        }
      }
    }

    private void VisitTreeImpl(MyFunc<float, float, float, float, int, int, KdTreeObject[], bool> visitor)
    {
      m_QueryStack.Push(0);
      while (m_QueryStack.Count > 0) {
        int node = m_QueryStack.Pop();

        int begin = m_KdTree[node].m_Begin;
        int end = m_KdTree[node].m_End;
        int left = m_KdTree[node].m_Left;
        int right = m_KdTree[node].m_Right;

        float minX = m_KdTree[node].m_MinX;
        float minZ = m_KdTree[node].m_MinZ;
        float maxX = m_KdTree[node].m_MaxX;
        float maxZ = m_KdTree[node].m_MaxZ;

        bool isVertical = (maxX - minX > maxZ - minZ);
        if (isVertical) {
          float splitValue = 0.5f * (maxX + minX);
                    /*
          if (!visitor(splitValue, minZ, splitValue, maxZ, begin, end, m_Objects)) {
            m_QueryStack.Clear();
            return;
          }
          */
          if(!visitor(minX, minZ, maxX, maxZ, begin, end, m_Objects))
                    {
                        m_QueryStack.Clear();
                        return;
                    }
        } else {
          float splitValue = 0.5f * (maxZ + minZ);
                    /*
          if (!visitor(minX, splitValue, maxX, splitValue, begin, end, m_Objects)) {
            m_QueryStack.Clear();
            return;
          }
          */
          if(!visitor(minX, minZ, maxX, maxZ, begin, end, m_Objects))
                    {
                        m_QueryStack.Clear();
                        return;
                    }
        }

        if (left > 0)
          m_QueryStack.Push(left);
        if (right > 0)
          m_QueryStack.Push(right);
      }
    }

    private static float Sqr(float v)
    {
      return v * v;
    }

    private static float CalcSquareDistToRectangle(float distMinX, float distMaxX, float distMinZ, float distMaxZ)
    {
      float ret = 0;
      if (distMinX > 0) ret += distMinX * distMinX;
      if (distMaxX > 0) ret += distMaxX * distMaxX;
      if (distMinZ > 0) ret += distMinZ * distMinZ;
      if (distMaxZ > 0) ret += distMaxZ * distMaxZ;
      return ret;
    }

    private KdTreeObject[] m_Objects = null;
    private int m_ObjectNum = 0;
    private KdTreeNode[] m_KdTree = null;
    private int m_MaxNodeNum = 0;
    private Stack<int> m_BuildStack = new Stack<int>(4096);
    private Stack<int> m_QueryStack = new Stack<int>(4096);
  }
}
