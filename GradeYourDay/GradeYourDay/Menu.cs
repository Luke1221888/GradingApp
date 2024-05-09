using static System.Console;



namespace GradeYourDay
{
    public class Menu
    {
        public static string welcome = @"                                                                                                                                                                  
        
                                                                                                                                                                             _.--,-```-.    
        ,--,                                                                                                                                                                /    /      '.  
      ,--.'|                                                                                                                                                               /  ../         ; 
   ,--,  | :                                                                                                                                       ,---,                   \  ``\  .``-    '
,---.'|  : '   ,---.           .---.                 .---.                                             ,---.           ,--,   __  ,-.            ,---.'|                    \ ___\/    \   :
|   | : _' |  '   ,'\         /. ./|                /. ./|              .--.--.                       '   ,'\        ,'_ /| ,' ,'/ /|            |   | :                          \    :   |
:   : |.'  | /   /   |     .-'-. ' |             .-'-. ' |  ,--.--.    /  /    '                .--, /   /   |  .--. |  | : '  | |' |            |   | |   ,--.--.        .--,    |    ;  . 
|   ' '  ; :.   ; ,. :    /___/ \: |            /___/ \: | /       \  |  :  /`./              /_ ./|.   ; ,. :,'_ /| :  . | |  |   ,'          ,--.__| |  /       \     /_ ./|   ;   ;   :  
'   |  .'. |'   | |: : .-'.. '   ' .         .-'.. '   ' ..--.  .-. | |  :  ;_             , ' , ' :'   | |: :|  ' | |  . . '  :  /           /   ,'   | .--.  .-. | , ' , ' :  /   :   :   
|   | :  | ''   | .; :/___/ \:     '        /___/ \:     ' \__\/: . .  \  \    `.         /___/ \: |'   | .; :|  | ' |  | | |  | '           .   '  /  |  \__\/: . ./___/ \: |  `---'.  |   
'   : |  : ;|   :    |.   \  ' .\           .   \  ' .\    ,"" .--.; |   `----.   \         .  \  ' ||   :    |:  | : ;  ; | ;  : |           '   ; |:  |  ,"" .--.; | .  \  ' |   `--..`;    
|   | '  ,/  \   \  /  \   \   ' \ |         \   \   ' \ |/  /  ,.  |  /  /`--'  /          \  ;   : \   \  / '  :  `--'   \|  , ;           |   | '/  ' /  /  ,.  |  \  ;   : .--,_        
;   : ;--'    `----'    \   \  |--""           \   \  |--"";  :   .'   \'--'.     /            \  \  ;  `----'  :  ,      .-./ ---'            |   :    :|;  :   .'   \  \  \  ; |    |`.     
|   ,/                   \   \ |               \   \ |   |  ,     .-./  `--'---'              :  \  \          `--`----'                      \   \  /  |  ,     .-./   :  \  \`-- -`, ;    
'---'                     '---""                 '---""     `--`---'                             \  ' ;                                          `----'    `--`---'        \  ' ;  '---`""     
                                                                                                `--`                                                                      `--`              


        ***********************************************
        *   Hello to simply app for rating your day   *
        ***********************************************
        ";

        protected static void DisplayMenu()
        {
            Title = "GradeYourDay";
            WriteLine("Type on keyboard '1' to add ratings of your day into file");
            WriteLine("Type on keyboard '2' to count your day statistics in program memory");
            WriteLine("Type on keyboard '3' to read numbers from file");
            WriteLine("Type on keyboard 'Q' to quit program");
            WriteLine("What will you do?");
        }

        protected static void DisplayInfo()
        {
            WriteLine("\n********************************************************");
            WriteLine("Type number from 0 to 10 to answer questions");
            WriteLine("Or type 'exit' to quit to main menu\n");
            WriteLine("0 means worst rating");
            WriteLine("10 means best rating");
            WriteLine("********************************************************\n");
        }
    }
}
