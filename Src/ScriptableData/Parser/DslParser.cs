#if FULL_VERSION
// DslParser.cs - generated by the SLK parser generator 

namespace ScriptableData.Parser {

class DslParser {

private static short[] Production = {0

,2,30,31 ,3,31,32,68 ,3,32,45,89 ,3,33,46,89 ,3,34,47,89 
,3,35,48,89 ,3,36,49,89 ,3,37,50,89 ,3,38,51,89 
,3,39,52,89 ,3,40,53,89 ,3,41,54,89 ,3,42,55,89 
,3,43,56,89 ,3,44,57,89 ,3,45,46,69 ,3,46,47,70 
,3,47,48,71 ,3,48,49,72 ,3,49,50,73 ,3,50,51,74 
,3,51,52,75 ,3,52,53,76 ,3,53,54,77 ,3,54,55,78 
,3,55,56,79 ,3,56,57,80 ,3,57,59,81 ,3,58,59,89 
,3,59,94,60 ,2,60,82 ,4,60,95,62,96 ,5,61,66,97,83,84 
,3,62,64,85 ,2,62,63 ,5,63,14,98,31,15 ,4,63,99,16,100 
,6,64,17,101,31,18,86 ,6,64,19,103,31,20,87 ,4,64,21,65,88 
,8,65,104,94,95,66,105,96,89 ,5,65,17,106,31,18 ,5,65,19,107,31,20 
,5,65,14,108,31,15 ,3,66,22,90 ,3,66,23,109 ,3,66,24,110 
,3,66,25,111 ,3,66,26,112 ,2,67,27 ,2,67,28 ,4,68,67,32,68 
,1,68 ,6,69,1,90,91,33,69 ,1,69 ,10,70,2,90,92,34,2,90,93,34,70 
,1,70 ,6,71,3,90,91,35,71 ,1,71 ,6,72,4,90,91,36,72 
,1,72 ,6,73,5,90,91,37,73 ,1,73 ,6,74,6,90,91,38,74 
,1,74 ,6,75,7,90,91,39,75 ,1,75 ,6,76,8,90,91,40,76 
,1,76 ,6,77,9,90,91,41,77 ,1,77 ,6,78,10,90,91,42,78 
,1,78 ,6,79,11,90,91,43,79 ,1,79 ,6,80,12,90,91,44,80 
,1,80 ,6,81,13,90,91,58,81 ,1,81 ,5,82,95,61,96,82 
,1,82 ,2,83,64 ,1,83 ,2,84,63 ,1,84 ,2,85,63 ,1,85 
,3,86,102,64 ,1,86 ,3,87,102,64 ,1,87 ,3,88,102,64 
,1,88 
,0};

private static int[] Production_row = {0

,1,4,8,12,16,20,24,28,32,36,40,44,48,52,56,60
,64,68,72,76,80,84,88,92,96,100,104,108,112,116,120,123
,128,134,138,141,147,152,159,166,171,180,186,192,198,202,206,210
,214,218,221,224,229,231,238,240,251,253,260,262,269,271,278,280
,287,289,296,298,305,307,314,316,323,325,332,334,341,343,350,352
,358,360,363,365,368,370,373,375,379,381,385,387,391
,0};

private static short[] Parse = {

0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2
,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3
,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3
,3,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4
,4,4,4,4,4,4,4,4,4,4,5,5,5,5,5,5,5,5,5,5
,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6
,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6
,6,6,6,6,6,6,6,6,7,7,7,7,7,7,7,7,7,7,7,7
,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,8,8,8
,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8
,8,8,8,8,8,8,9,9,9,9,9,9,9,9,9,9,9,9,9,9
,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,10,10,10,10,10
,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10
,10,10,10,10,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11
,11,11,11,11,11,11,11,11,11,11,11,11,11,12,12,12,12,12,12,12
,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12
,12,12,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13
,13,13,13,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14
,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14
,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15
,15,15,15,15,15,15,15,15,15,16,16,16,16,16,16,16,16,16,16,16
,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,16,17,17
,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17
,17,17,17,17,17,17,17,18,18,18,18,18,18,18,18,18,18,18,18,18
,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,18,19,19,19,19
,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19
,19,19,19,19,19,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20
,20,20,20,20,20,20,20,20,20,20,20,20,20,20,21,21,21,21,21,21
,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21
,21,21,21,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22
,22,22,22,22,22,22,22,22,22,22,22,22,23,23,23,23,23,23,23,23
,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23
,23,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24
,24,24,24,24,24,24,24,24,24,24,25,25,25,25,25,25,25,25,25,25
,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,26
,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26
,26,26,26,26,26,26,26,26,27,27,27,27,27,27,27,27,27,27,27,27
,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,28,28,28
,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28
,28,28,28,28,28,28,29,29,29,29,29,29,29,29,29,29,29,29,29,29
,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,30,30,30,30,30
,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30,30
,30,30,30,30,31,31,31,31,31,31,31,31,31,31,31,31,31,32,31,32
,32,31,32,31,32,31,31,31,31,31,31,31,31,83,83,83,83,83,83,83
,83,83,83,83,83,83,83,83,83,82,83,82,83,82,83,83,83,83,83,83
,83,83,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,89,88,89
,88,89,88,89,89,89,89,89,89,89,89,91,91,91,91,91,91,91,91,91
,91,91,91,91,91,91,91,90,91,90,91,90,91,91,91,91,91,91,91,91
,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,93,92,93,92,93
,92,93,93,93,93,93,93,93,93,1,1,1,1,1,1,1,1,1,1,1
,1,1,1,0,1,1,36,1,37,1,1,1,1,1,1,1,1,1,85,85
,85,85,85,85,85,85,85,85,85,85,85,84,85,84,38,85,39,85,40,85
,85,85,85,85,85,85,85,81,81,81,81,81,81,81,81,81,81,81,81,81
,35,81,35,34,81,34,81,34,80,80,80,80,80,81,81,81,87,87,87,87
,87,87,87,87,87,87,87,87,87,86,87,86,0,87,0,87,33,33,33,33
,33,0,87,87,87,79,79,79,79,79,79,79,79,79,79,79,79,78,44,79
,0,42,79,43,79,0,41,41,41,41,41,79,79,79,77,77,77,77,77,77
,77,77,77,77,77,76,50,51,77,0,0,77,0,77,45,46,47,48,49,0
,77,77,77,75,75,75,75,75,75,75,75,75,75,74,0,0,0,75,0,0
,75,0,75,0,0,0,0,0,54,75,75,75,73,73,73,73,73,73,73,73
,73,72,55,0,0,55,73,55,0,73,0,73,0,0,55,55,55,0,73,73
,73,71,71,71,71,71,71,71,71,70,0,0,0,0,0,71,0,0,71,0
,71,0,0,0,59,59,58,71,71,71,69,69,69,69,69,69,69,68,59,0
,0,59,0,59,69,0,0,69,0,69,59,59,59,0,0,0,69,69,69,67
,67,67,67,67,67,66,0,0,0,0,0,0,0,67,0,0,67,0,67,65
,65,65,65,65,64,67,67,67,0,0,0,0,0,65,0,0,65,0,65,63
,63,63,63,62,0,65,65,65,0,0,0,0,0,63,0,0,63,0,63,61
,61,61,60,57,56,63,63,63,0,0,0,0,0,61,0,0,61,57,61,0
,57,0,57,0,0,61,61,61,0,57,57,57,53,0,0,53,0,53,0,0
,0,0,0,0,52,52,53
};

private static int[] Parse_row = {0

,987,1,30,59,88,117,146,175,204,233,262,291,320,349,378,407
,436,465,494,523,552,581,610,639,668,697,726,755,784,813,842,1073
,1045,991,1016,1103,1131,1118,1356,1186,1341,1242,1337,1317,1297,1277,1248,1219
,1190,1161,1132,1103,1045,871,1016,1074,900,929,958
,0};

private static short[] Conflict = {

0
};

private static int[] Conflict_row = {0


,0};

private static short get_conditional_production ( short symbol ) { return (short) 0; }

private const short   END_OF_SLK_INPUT_ = 29;
private const short   START_SYMBOL = 30;
private const short   START_STATE = 0;
private const short   START_CONFLICT = 94;
private const short   END_CONFLICT = 94;
private const short   START_ACTION = 89;
private const short   END_ACTION = 113;
private const short   TOTAL_CONFLICTS = 0;

internal const int   NOT_A_SYMBOL = 0;
internal const int   NONTERMINAL_SYMBOL = 1;
internal const int   TERMINAL_SYMBOL = 2;
internal const int   ACTION_SYMBOL = 3;

internal static short[]
GetProductionArray ( short  production_number )
{
   short   index = (short)  Production_row [ production_number ],
           array_length = (short)  Production [ index ],
           new_index = 0;
   short[] productionArray = new short[17];        

   while ( array_length-- >= 0 ) {
       productionArray [ new_index++ ] = Production [ index++ ];
   }
   return  productionArray;
}

internal static int GetSymbolType ( short   symbol )
{
   int   symbol_type = NOT_A_SYMBOL;

   if ( symbol >= START_ACTION  &&  symbol < END_ACTION ) {
       symbol_type = ACTION_SYMBOL;
   } else if ( symbol >= START_SYMBOL ) {
       symbol_type = NONTERMINAL_SYMBOL;
   } else if ( symbol > 0 ) {
       symbol_type = TERMINAL_SYMBOL;
   }
   return  symbol_type;
}

internal static bool    IsNonterminal ( short   symbol )
{
   return ( symbol >= START_SYMBOL  &&  symbol < START_ACTION );
}

internal static bool    IsTerminal ( short   symbol )
{
   return ( symbol > 0  &&  symbol < START_SYMBOL );
}

internal static bool    IsAction ( short   symbol )
{
   return ( symbol >= START_ACTION  &&  symbol < END_ACTION );
}

internal static short GetTerminalIndex ( short   token ){
 return ( token );
}

internal static short
get_production ( short     conflict_number,
                 DslToken  tokens )
{
    short   entry = 0;
    int     index, level;

    if ( conflict_number <= TOTAL_CONFLICTS ) {
        entry = (short) ( conflict_number + (START_CONFLICT - 1) );
        level = 1;
        while ( entry >= START_CONFLICT ) {
            index = Conflict_row [entry - (START_CONFLICT -1)];
            index += tokens.peek ( level );
            entry = Conflict [ index ];
            ++level;
        }
    }

    return  entry;
}

private static short
get_predicted_entry ( DslToken   tokens,
                      short      production_number,
                      short      token,
                      int        scan_level,
                      int        depth )
{
 return  0;
}

internal static void
parse ( DslAction   action,
        DslToken    tokens,
        DslError    error,
        short       start_symbol )
{
 short     lhs;
 short     production_number, entry, symbol, token, new_token;
 int       production_length, top, index, level;
 short[]   stack = new short[512];

 top = 511;
 stack [ top ] = 0;
 if ( start_symbol == 0 ) {
     start_symbol = START_SYMBOL;
 }
 if ( top > 0 ) { stack [--top] = start_symbol;
 } else { error.message ("DslParse: stack overflow\n"); return; }
 token = tokens.get();
 new_token = token;

 for ( symbol = (stack[top] != 0  ? stack[top++] : (short) 0);  symbol != 0; ) {

     if ( symbol >= START_ACTION ) {
         action.execute ( symbol - (START_ACTION-1) );

     } else if ( symbol >= START_SYMBOL ) {
         entry = 0;
         level = 1;
         production_number = get_conditional_production ( symbol );
         if ( production_number != 0 ) {
             entry = get_predicted_entry ( tokens,
                                           production_number, token,
                                           level, 1 );
         }
         if ( entry == 0 ) {
             index = Parse_row [ symbol - (START_SYMBOL-1) ];
             index += token;
             entry = Parse [ index ];
         }
         while ( entry >= START_CONFLICT ) {
             index = Conflict_row [entry - (START_CONFLICT -1)];
             index += tokens.peek (level);
             entry = Conflict [ index ];
             ++level;
         }
         if ( entry != 0 ) {
             index = Production_row [ entry ];
             production_length = Production [ index ] - 1;
             lhs = Production [ ++index ];
             if ( lhs == symbol ) {
                 action.predict ( entry );
                 index += production_length;
                 for (;  production_length-- > 0;  --index ) {
                     if ( top > 0 ) { stack [--top] = Production [index];
                     } else { error.message ("DslParse: stack overflow\n"); return; }
                 }
             } else {
                 new_token = error.no_entry ( symbol, token, level-1 );
             }
         } else {                                       // no table entry
             new_token = error.no_entry ( symbol, token, level-1 );
         }

     } else if ( symbol > 0 ) {
         if ( symbol == token ) {
             token = tokens.get();
             new_token = token;
         } else {
             new_token = error.mismatch ( symbol, token );
         }

     } else {
         error.message ( "\n parser error: symbol value 0\n" );
     }

     if ( token != new_token ) {
         if ( new_token != 0 ) {
             token = new_token;
         }
         if ( token != END_OF_SLK_INPUT_ ) {
             continue;
         }
     }

     symbol = (stack[top] != 0  ? stack[top++] : (short) 0);
 }

 if ( token != END_OF_SLK_INPUT_ ) {
     error.input_left ();
 }

}

};

}
#endif