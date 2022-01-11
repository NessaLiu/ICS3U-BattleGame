using System;

//Vanessa Liu
//Gr. 11 Computer Science Unit 2 Programming Assignment
//Created May 26, 2020. Completed June 5, 2020.
//Option 2: Battle Game - This program allows the player to battle against a computer opponent. 

class MainClass {

  //number of characters stored in the program
  const int NUMBER_OF_CHARACTERS = 3;

  //store the characters' data
  static string[] names = new string[NUMBER_OF_CHARACTERS];
  static string[] pictures = new string[NUMBER_OF_CHARACTERS];
  static int[] maxHealth = new int[NUMBER_OF_CHARACTERS];
  static int[] currentHealth = new int[NUMBER_OF_CHARACTERS];
  static int[] normalAtkPwr = new int[NUMBER_OF_CHARACTERS];
  static int[] specialAtkPwr = new int[NUMBER_OF_CHARACTERS];
  static int[] healPwr = new int[NUMBER_OF_CHARACTERS];
  //Determines if the special attack is available for use for both players. True is available, false if not.
  static bool[] recharge = new bool[NUMBER_OF_CHARACTERS];
  
  //keep track of which character the user is looking at
  static int currentIndex = 0;

  //keep track of which character the user selects
  static int selectedIndex = 0;

  //keep track of the character the computer chooses
  static int enemyIndex = 0;

  //create a random number generator
  static Random randomNumber = new Random();

  public static void Main (string[] args) {

    CharacterSelectionMenu();

  }

  //Create character data
  static void CreateCharacters()
  {
    names[0] = "Blossom";
    names[1] = "Bubbles";
    names[2] = "Buttercup";

    maxHealth[0] = 500;
    maxHealth[1] = 300;
    maxHealth[2] = 400;

    //assign random values for the current health --> it will be given a proper value when the game starts
    currentHealth[0] = 100;
    currentHealth[1] = 100;
    currentHealth[2] = 100;

    normalAtkPwr[0] = 50;
    normalAtkPwr[1] = 70;
    normalAtkPwr[2] = 60;

    specialAtkPwr[0] = 170;
    specialAtkPwr[1] = 180;
    specialAtkPwr[2] = 160;

    //the special attack starts off available for all players
    recharge[0] = true;
    recharge[1] = true;
    recharge[2] = true;

    healPwr[0] = 90;
    healPwr[1] = 40;
    healPwr[2] = 70;

    pictures[0] = @"MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWN0kolc:,'.... lNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWXko:,'..'',,;;;;..dWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMN0d:,..',;;::;;;;;;,.;KMMMMMMMMMMMMMMMMMMMWWNXK0OOkxxxxxx
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMW0d;'.',;;;;;;;;;;;;;;..xWMMMMMMMMMMMMMWKOxol:;;,''.........
MMMMMMMMMMMMMMMMMMMMMMMMMMMMNkc'.';;;;;;;;;;;;;;;;;'.lNMMMMMMMMMWKkoc;'...'',,;;;;;;;;:,.'
MMMMMMMMMMMMMMMMMMMMMMMMMMNx;..,;;:;;;;;;;;;;;;;;;'.:KMMMMMMWXkl;'..',;;;;;;;;;;;;;;;;;..d
MMMMMMMMMMMMMMMMMMMMMMMMWk;.';;;;::;;;:;;;;;;;;;;'.;KMMMMWXxc,..,;;;;;;;;;;;;;;;;;;;;;'.cX
MMMMMMMMMMMMMMMMMMMMMMMXl..,;;;;;;;;::;;;:;;;;;;'.:KMMMNOl,.',;:;;;;;;::;;;;;;;;;;;;;'.:KM
MMMMMMMMMMMMMMMMMMMMMW0;.';;::;;;;;;;;;;;;;;;;;'.cKMMNk:..,;;;;;;;;;;;;;;;;;;;;;;;;;'.;0MM
MMMMMMMMMMMMMMMMMMMMWO,.,;;;;;;;;;;;;;;;;;;;;,..oXMW0:..,;:;;:;;:;;;;;;;;;;;;;;;;:;'.;0MMM
MMMMMMMMMMMMMMMMMMMMK;.,;;;:;;:;;;;;;;;;;;;,..,kNMXo'.,;;;;:;;;;;;;;;;;;;;;;;;;;;;'.:KMMMM
MMMMMMMMMMMMMMMMMMMNl.';:;;;:;;;;;;;;;;;;;..:x0WMKc.';;;;;;:;;:;;;;;;;;;;;;;;;;;;..lXMMMMM
MMMMMMMMMMMMMMMMMMM0,.;:;;;;;;;;;;,,'''''..c0XXN0;.';;;;;;;;;;;;;;;;;;;;:;;;;:;,.'xNMMMMMM
MMMMMMMMMMMMMMMMMMMk..;;;:;;;;;;'..........',,,,..';;;:;;;;;;;;;;;;;;;;;;;;;;;'.;0WMMMMMMM
MMMMMMMMMMMMMMMMMMMx..;;;::;:;;'..,;;;;;;;;;;;,..';;;;;:;;;;;;;;;;;;;;;;;:;;,.'dXMMMMMMMMM
MMMMMMMMMMMMMMMMMMMO'.;;,,'....   ............. .';;;:;;;;;;;;;;;;;;;;;;;;,..c0WMMMMMMMMMM
MMMMMMMMMMMMMMMMMWNk' .......',;;;;'';::;;,''.........',;;:;;;;;;;;;::;;,..:kNMMMMMMMMMMMM
MMMMMMMMMMMMMMN0xc'...';cloxxkxdlccc,ckkkkkkkkxdol:;'.. ..',;;;;;;;::;,..:kNMMMMMMMMMMMMMM
MMMMMMMMMMMW0o;...,;cdxkkkkkdl:cokKKl;dkkkkkkkkkkkkkkdc;,.  .',;;;;,..'lONMMMMMMMMMMMMMMMM
MMMMMMMMMXx;...;clodxkkkkkdc:oOXNNNNk;lkkkkkkkkkkkkkkkd:;::;.  ....,cxXWMMMMMMMMMMMMMMMMMM
MMMMMMWXd'..;lllloxkkkkkdccd0NNNNNNNKc;xkkkkkkkkkkkkkkkd;..:lc,.  ;OWMMMMMMMMMMMMMMMMMMMMM
MMMMMXd' .:ooccdkkkkkkxc:dKNNNNNNNNNXx;lkkkkkkkkkkkkkkkkxc..':do;..,kNMMMMMMMMMMMMMMMMMMMM
MMMWO; .;od:,:lllllc:;;lOXNNNNNNNNNNN0c;oddxkkkkkkkkkkkkkkl'...lxo, .cKWMMMMMMMMMMMMMMMMMM
MMNx.  .;'.   .,dOOkl;oKNNNNNNNNNNNNNNO:;llc:::::clodxkkkkkl.  .:xxc. 'OWMMMMMMMMMMMMMMMMM
MNo. .::.     :KMMMMW0x0NNNNNNNNNNNNNKxxKXOdollc:'. ...,;cloc.   ,dko. .kWMMMMMMMMMMMMMMMM
Wd. 'll'      oWMMMMMNdxXNNNNNNNNNNN0dkNXOddoool'          ...    ,dko' .kWMMMMMMMMMMMMMMM
k. .lo,       ,OWMMMWx,lXNNNNNNNNNNKdkNNOdddooc.           .:odxdlc:loc. ,0MMMMMMMMMMMMMMM
: .:dc.        .:ool;. :KNNNNNNNNNXkdXW0ddodlc'           ,0WMMMMMW0l...  oNMMMMMMMMMMMMMM
. 'ld;                 cXNNNNNNNNNKdOWNkdddd:'.           oWMMMMMMMMX:    ,0MMMMMMMMMMMMMM
  ,od:.               .oXNNNNNNNNN0d0MXxdddo;.            'OWMMMMMMMK;    .kMMMMMMMMMMMMMM
  ;ddl.               ,ONNNNNNNNNNOd0MXxdddo;..            .:x0KXKOo'     .xWMMMMMMMMMMMMM
  ;odoc.            .'dXNNNNNNNNNN0dOMNkddddl;.                ...        .xMMMMMMMMMMMMMM
  ,oddoc'.        .,;dKNNNNNNNNNNNXxxWW0ddddoo:.                          .OMMMMMMMMMMMMMM
' .cddddol;'...';cc:dKNNNNNNNNNNNNN0d0WNOdddddo:.                         :XMMMMMMMMMMMMMM
o. ;ddddddddooodocckXNNNNNNNNNNNNNNXkdKWNOdddddol,.                  .'. .kWMMMMMMMMMMMMMM
X: .:xOOkxxxxkxooxKNXKXNNNNNNNNNKdo0Xkd0WN0xddoddoc;.             ..;c,  lNMMMMMMMMMMMMMMM
M0,  ;xkkOkkkkkOKNNNXx:lxOOOOxoc'  cKN0xkXWX0kxdddddoc:,'......',:loo;  cXMMMMMMMMMMMMMMMM
MM0; .ckOOOO0KXNNNNNNk.  ....      .kNNXOxkKNWNKOxdddddddoooooodddxd; .cXMMWWWMMMMMMMMMMMM
MMMXl..;OXNNNNNNNNNNNKc         ....dXNNNXOkkkO0XXX0OkkxxxxxxkOO0ko' .lOkoc:;;:xXMMMMMMMMM
MMMMWk, .l0XNNNNNNNNNNO;      'coo:;kNNNNNNNK0OkkkOO0KKXXKKKK0Okl.   .,,,:ldxd,.dWMMMMMMMM
MMMMMMXd' .cOXNNNNNNNNNO:.   'odoc;dXNNNNNNNNNNNXK0Okkkkkkkkkxc'. .';ldOKXNNN0,.xWMMMMMMMM
MMMMMMMWXd,..;d0XNNNNNNNKkc'.,cccoOXNNNNNNNNNNNNNNNNNNNNNNXOo,..;dOKXNNNNNNXO;.lXMMMMMMMMM
MMMMMMMWNX0d;. .;okKXNNNNNXK0OO0KXNNNNNNNNNNNNNNNNNNNNXKkl,..'lkXNNNNNNNNXOc''dNMMMMMMMMMM
MMMMW0o:;;,,,..   .':oxOKXNNNNNNNNNNNNNNNNNNNNNNXXKOxl;...,lkKNNNNNNNXKkl;',oKMMMWOOWMMMMM
MMMM0,.cxOOOOOkxxdoc,...';:loxkkO00KKKK00Okxddol:,..   .;okO000Okxdoc;,,;oONMMMWKc.'0MMMMM
MMMMX:.cOXNNNNNNNNNNX0kdl:,.   ................  .;cc:,,'''',,'....:ldOXWMMMMW0l..  oWMMMM
MMMMMXo,':dOKXNNNNNNXXKOxl;.'cl' .;;;;;;,,,''''. .;dkkkkxxxddddl,..:dOKXNXKOd;..;o; ;KMMMM
MMMMMMMXkc,,,;cllllc:;,,;coOXWNc 'lc:,'..          .:dkkkxoc,''',;;,..'''''.',cdkkl..OMMMM
MMMMMMMMMMNKkdollllloxOKNWMMMMWd. .            ...'...:lc'.       ,dxdolllodxkkkkko..kMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMO.         .',;:loodo:.  .;dko, .'..ckkkkkkkkkxddddc..kMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNc      .,:lodddddol;,,;ckNMMMNxc;..ckkkkkkkkkxdoll, '0MMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMk.  .':oodddddol;'':d0NMMMMMMMNo. ;xkkkkkkkkkkkkkx; :XMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNc .coddddol:,'.. ,kNWMMMMMWKx;..cxkkkkkkkkkkkkkkl..kWMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM0' ,oddol;.  .:o:'.,coddol;..,cxkkkkkkkkkkkkkkko..lNMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWx..:ol;';l;...:dxo:;'''',:ldkkkkkkkkkkkkkkkkko'.cXMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNd..'',xNMNXOc..:dkkkkkkkkkkkkkkkkkkkxxkkkkxc..lXMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNo. ;KMMMMMMW0c..:xkkkkkkkkkkkkkkkkkdolodl'.,kNMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNo.'kWMMMMMMMWO;.'lkkkkkkkkkkkkkkkkkkl'..'oXMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNd..dNMMMMMMMMNd..cxkkxoxkkkkkkkkdl;..;dXWMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWO,.cKWMMMMMMWk' .:xkxccdxdol:;'..;o0NMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMKl.'xKNMMWKo.    .''.....'',cokKWMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWO;..,dxooo'    ;xxdxxkOKXWMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNkoc'..:l.   'OMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMW0o,.    ,kWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM";
    pictures[1] = @"MMMMMMMMMMMMMMMMMMMMMMMMMMMMNXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMKldNMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMWx,dNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNl..xWM
MMMMMMMMMMMMMMMMMMMMMMMMMMMK:..oNMMMMMWNXK0OkkkkkkkO0KXNWMMMMMMMMMMMMMMMMMMMMMMMWXk:,c,,OM
MMMMMMMMMMMMMMMMMMMMMMMMMNO:,dl'lK0xoc;;,,,,,,,,,,,,,,,,;cokKNMMMMMWKkdolllooollc::oOXd.lN
MMMMMMMMMMMMMMMWNXKK0Okdl::oO0o...',:coxkO0KKKXXXXKK0Okxoc;'',cxKKxc;:lodddddddxk0XXXN0;,0
MMMMMMMMMMMMNOocc:cccccldkko;'';lx0KXXNNNXXXXXXXNNXXXXXXNXX0ko;..';o0XNNNNNNNNNNNXXXXNKc,O
MMMMMMMMMMNx:;lxOKKXXXX0d:''cd0XXNNNXXXXXXXNNXXNNNNNNXXXXNXXNNKl.:0XNXNXXNNNNXXXNXXXXNKc,0
MMMMMMMMMKc,o0XNXNNXX0o,.;d0XXKXNNNXXXXXXXXXXNNXXNNXXXXXXXXXXNO,;0NXXXNXXNNXXXNNXXXXXNO,;K
MMMMMMMMXc'xXNNXNXXKo'.:kKNXXxcdOXNXXXXXNNNNXXNXNNXXNXXNNXXXXXd.lXXXXXXXXXXXXXNXXXXXNXo'dW
MMMMMMMMk'cKNXXNXXk;.;kXNXNXOloxddk0XXXXNXXXNNNXXXXXXXXXXNNXXXx'cKNXXNNXXXXXXXXXXXXXXd'cXM
MMMMMMMMx.oXNXXNKo..oKXXNNXOldKNX0xddxk0KXXNNNXXXXXXXXNXNNXXKOo..xXXXNNXNXXXXXXXXXX0l'lXMM
MMWWWMMM0,:0NNNKl.'kXXXXXXklxXNNNNNXKOoldxdddxxxkkkkxxxdol:;'.   .oKXNNXNNNNXNNNX0d;;xNMMM
WOccclkXNd'c0NKl.'kXNNNXOooOXNNNNNNNNXkkN0dcccccc;.                ,oOKXXNNXXKOxc;:xXMMMMM
K,,kko;;xKx;;dl..xXNX0kocxXNNNNNNNNNNKx0Nkdoooodl'                   ..;:cccc::cd0NMMMMMMM
0,;KNNKo;;dOd;..l0OxoccoooOXNNNNNNNNN0xKKxoooooo,                         .l0KNWMMMMMMMMMM
Nl'dXNNNKd:;lc..;lccclccccckXNNNNNNNNKx00doooooc.            .;oxkxc'     .OMMMMMMMMMMMMMM
MK:,xXNNNNKkc. .cooc,.   ..'dXNNNNNNNXkO0doooooc.           .dNMMMMWK:    ;KMMMMMMMMMMMMMM
MMXl,lOXNNNNKc .loc.        .dXNNNNNNN0xOkoooddl.           ;KMMMMMMMk.  .dWMMMMMMMMMMMMMM
MMMNOc;cdOKXXl .cl'          'kNNNNNNNXOxkxoodoo;.          .xNMMMMMXc   :XMMMMMMMMMMMMMMM
MMMMMW0dc::cc, .:c.           cKNNNNNNNXOxxddoooo;.          .;dkkxo'   ,0MMMMMMMMMMMMMMMM
MMMMMMMMWNKOxd, .;.    .ckOkc.'ONNNNNNNNX0kddddoooc'                   ;0MMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMM0, ..    cNMMMWk:xNNNNNNNNX0K0kxdoooooc,.           ....:KWMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMW0, .    cXMMMMXxkNNNNNNXOc.,xKXKOxdolllc:;'.....,:c,. .:ccldKWMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMKc.    .cKWMNkd0NKOkxo;.   'd0XNNXKOkkxxxxxxkOOkc..cxOOOkd:,oXMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMNx'     .;:,;xXN0l.     .::cdONNNNNNNNNNNNX0d;..,d0XNNNNNXo'oNMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMXd,     .:kXNNNKd;.  .:lcdOKNNNNNNNNNXOd:'.',;cc::lxKXNN0,;KMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMNkc' .,oOKXNNNNXOdcldxkXNNNNNXX0kdc,.. .lKWWWNXOo:;lk0d'cXMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMNOo:,'';cloxkkOO0OOOkkxdoc:,'..';clc'.c0WMMMMMNOl:::oKMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMWN0kdl:;,,,,,,,,,,,;;::...,,,,;;::,..dNMMMMMMMWNNWMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNXXXKKKXXNNNWMWd.             cKMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMX;              ,OWMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWO;  .';;;;;,'.....xNMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMXl':oo:'':ododdoolc..dNMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWx.:O0Oko..,loddoddol'.dNMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWd.;xkOkc.  .,,,,;::::..dNMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM0,'xK0o.   .ll..lxdol:..xWMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWO,...     cNNl.xWMMMWO,'OMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWKo'.   .cKMMx.cNMMMMWk';KMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWN0xdx0WMMMK;'OMMMMMNo.oWMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWd.lNMMMMM0,,0MMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMK;'OMMMMWNl.dWMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMk',dxkkkk:.lWMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWd. .cOK0:.dWMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNx'  .'..;KMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMW0c.   :0MMMMMMMMMMMMMMM";
    pictures[2] = @"MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWXOxl:,...            ..';cldOKNWMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMWKxl,.                            .':dOXWMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMWKd:.                                     .:d0NMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMNOc.                                           .,o0WMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMWO:.                                          .;'   .;xXMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMKl.                                           .oKx.     'dXWMMMMMMMMMMMM
MMMMMMMMMMMN0XMMWO,                                            .dXNKl       'dXMMMMMMMMMMM
MMMMMMMMMMMO,;kXk'                                            'xXNNNO'        ,OWMMMMMMMMM
MMMMMMMMMMMx.  .. .;::'        ,dkkxdolc;.                   ,kXNNNNKc         .oXMMMMMMMM
MMMMMMMMMMWd.    .;ll,.       ;0MMMMMMMMWx.       .''..     :0NNNNNNXx.          :KMMMMMMM
MMMMMMMMMMWd.    ,ll:.        :XMMMMMMMMMO.        'lkkxl::oKNNNNNNNNO'           ;0MMMMMM
MMMMMMMMMMMk.   .:ol,         .lKWMMMMMWO;         .,;o0XNXXNNNNNNNNN0;            :XMMMMM
MMMMMMMMMMMK,   .col,           .:odxdl,.          .cc,;lOXNNNXXXNNNNKc             lNMMMM
MMWXOxddxk0Kl   .cll;.                             'llodc,ckX0x0XXKKXXOc'.          .OMMMM
WOc,,;:c:;,,'   .lolc.                            .:lld0kll:;:xXN0dONNNNKOo,.        lNMMM
l.,xKXNNXX0x:.  .ldll:.                          .,lloO0dkX0dxXNKo;odddoooc,.        ,KMMM
.:0NNNNNNNNNXk,  ckdll:.                        .;llokKxxXNNNNNNKc'lxkO0KKx.         '0MMM
.lKXXXXXXXXXNNk' .x0dllc,.                    .'clloOKkxKNNNNNNNO;;KMMMMMMK;     .,. '0MMM
:';;;;;;;;::cloc. .x0koolc;..             ..,:clloxKKkxKNNNNNNNKc .oNMMMMNd.     ,c. .xNWW
WKOkkkkOOkkxol:,.  .cO0kdollc:,'.......',;clollok0XOxOXNNNNNNNNx.   ,lddl,      .:;.  .',c
MMMMMMMMMMMMMMWXOl. .:xO00kxoollllllllllloodkO0KKOkkKXNNNNNNNNKc                ,c'     .l
MMMMMMMMMMMMMMMMMWKc..cxkkOOOOOOkkxxxkkOO00000OOkOKXNNXNNNNNXN0;               'c,     .lX
MMMMMMMMMMMMMMMMMMMNd..;xK0OOOOOOOOOOOOOOOOOOO0XXXXXXNNNNNNNNNO:.            .,c,     .dNM
MMMMMMMMMMMMMMMMMMMMW0c..:kXNNXXKK00000KKXXNNNNNKkOXNNXNNNNNNNOc;'          ':c'    .:0WMM
MMMMMMMMMMMMMMMMMMMMWKx,  .:xKNNNNNNNXNNNNNNNNNXdl0NNNNNNNXXXNKl:l;..   ..,:c;.   .;kNMMMM
MMMMMMMMMMMMMMMMMMNkc...','..'lkKXNNNXNNNNNNNNNXx:oO0K0OkkOKXNXxloolcc:cclc;.   .:kNMMMMMM
MMMMMMMMMMMMMMMMWKc.  .:lolc,...,lkKXNNNNXNNNNNNXOdoooddk0XNNNNKxdOOkxdoc,.  .,o0WMMMMMMMM
MMMMMMMMMMMMMMMMK;     .;lllllc;....:lx0KXNNNNNNNNNXXXXXNNNNNNNNKkxxxd:.. .;o0NMMMMMMMMMMM
MMMMMMMMMMMMMMMWo        .;clloo:..;:'..';coxkk0KKXXXXXXXXXXK0Oxoc,. .':okKWMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMNc          ..',;. :XWN0xoc;'.....',,;;;;;;,''...  .cx0NWMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMWo..;.            .dWMMMMMMWNK00kxdolllcc:. .ldxkx;.cXMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMK;....;oxx:.      dWMMMMMMMMMMMMMMMMMMXx;':kXNNNNK:.dWMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMO' .:xO0KXo..';. :XMMMMMMMMMMMMMMMMMNl.:OXNNNNNN0;.dWMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMO' .lxxxddc..;oc..dWMMMMMMMMMMMMMMMMNl.;xOOOOkdc,,dXMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMWd  .oNMMMNo..:ol;..xWMMMMMMMMMMMMMMMMXxc;;;;;;:lxXWMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMWo   .l0NXx' .:cc:' .xWMMMMMMMMMMMMMMMMMMNNXXNWWMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMO'    ...   .::::c;.'0MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMWk,      .. lNWWWWXc.lNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMXklccok0:.oWMMMMMk.'0MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMMK,.xWMMMMM0'.kMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMWx.,KMMMMMMK,.xMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMK;.dWMMMMMMO'.OMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMNl.;KMMMMMMWo.;XMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMk. .cxOKNWWk'.kWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMWl     .cxdc..xWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMWo      cx:.,kWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMXc.     .'oKMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
MMMMMMMMMMMMMMMMMMMMMMMMMXo.   .l0WMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM";

  }

  //Menu 1: Select a Character.
  //The user can see 1 character's number picture and attributes at a time.
  static void CharacterSelectionMenu()
  {
    //run the CreateCharacters subprogram to obtain the data for each character.
    CreateCharacters();

    Console.WriteLine();
    Console.WriteLine("CHARACTER SELECTION MENU");
    Console.WriteLine("");

    //Display the current character
    PrintCurrentCharacter();

    //store the user's input
    string input;

    //loop the menu until a valid choice is inputted
    do{
      Console.WriteLine();
      Console.WriteLine("1. See next character.");
      Console.WriteLine("2. See previous character.");
      Console.WriteLine("3. Choose current character.");
      Console.WriteLine("4. Choose Character Number: ");
      Console.WriteLine("5. Exit Program");
      Console.WriteLine();

      //ask the user what they want to do
      Console.Write("Input choice: ");
      input = Console.ReadLine();
      Console.WriteLine();

      //check the menu option the user inputted and take action accordingly
      if (input == "1")
      {
        //show the next character
        ShowNextCharacter();

      }
      else if (input == "2")
      {
        //show previous character
        ShowPreviousCharacter();
      }
      else if (input == "3")
      {
        //choose current character for the player
        currentIndex = selectedIndex;
        Console.WriteLine("You have selected " + names[selectedIndex] + "! Let's start the game.");
        //Go to menu 2 to play the game
        GamePlayMenu();
        return;

      }
      else if (input == "4")
      {
        //Allow user to input a number. When a valid number is inputted, select that character.
        Console.Write("Input the number of your character choice: ");
        //take the user's selection as an int and check if it is valid
        int.TryParse(Console.ReadLine(), out int userSelection);

        //tell the user who they have selected depending on the number they input
        if (IndexOfSelectedCharacter(userSelection) == 0)
        {
          //the user chose the first character
          selectedIndex = 0;
          Console.WriteLine("You have selected Blossom! Let's start the game.");
          //Go to menu 2 to play the game
          GamePlayMenu();
          return;

        }
        else if (IndexOfSelectedCharacter(userSelection) == 1)
        {
          //the user chose the second character
          selectedIndex = 1;
          Console.WriteLine("You have selected Bubbles! Let's start the game.");
          //Go to menu 2 to play the game
          GamePlayMenu();
          return;
        }
        else if (IndexOfSelectedCharacter(userSelection) == 2)
        {
          //the user chose the third character
          selectedIndex = 2;
          Console.WriteLine("You have selected Buttercup! Let's start the game.");
          //Go to menu 2 to play the game
          GamePlayMenu();
          return;
        }
        else if (IndexOfSelectedCharacter(userSelection) == -1)
        {
          //notify the user that they have inputted an invalid answer
          Console.WriteLine("Invalid choice. Try again.");
          Console.WriteLine();
        }
      }
    
    } while(input != "5");
    
  }

  //print out the data of the current character shown
  static void PrintCurrentCharacter()
  {
    //show the character's number depending on the current index
    if (currentIndex == 0)
    {
      //this is the first character
      Console.WriteLine("Character 1:");
    }
    else if (currentIndex == 1)
    {
      //this is the second character
      Console.WriteLine("Character 2:");
    }
    else if (currentIndex == 2)
    {
      //this is the third character
      Console.WriteLine("Character 3:");
    }
    
    Console.WriteLine();
    Console.WriteLine(pictures[currentIndex]);
    Console.WriteLine();

    Console.WriteLine("Maximum Health: " + maxHealth[currentIndex]);
    Console.WriteLine("Normal Attack Power: " + normalAtkPwr[currentIndex]);
    Console.WriteLine("Special Attack Power: " + specialAtkPwr[currentIndex]);
    Console.WriteLine("Healing Power: " + healPwr[currentIndex]);
  }

  //Option 1 in menu 1 - show the next character when there is a next character to show
  static void ShowNextCharacter()
  {
    //show the next character if the current character is not last in the array
    if (currentIndex != names.Length - 1)
    {
      currentIndex = currentIndex + 1;
    }

    //display next character
    PrintCurrentCharacter();

  }

  //Option 2 in menu 1 - show the previous character when there is one to show
  static void ShowPreviousCharacter()
  {
    //show the previous character if the current character is not the first in the array
    if (currentIndex != 0)
    {
      currentIndex = currentIndex - 1;
    }

    //display the precious character
    PrintCurrentCharacter();

  }


  //1. Used when "Choose Character Number" option is chosen in Menu 1: Select Character.
  //Calculate + return index number of the selected character
  static int IndexOfSelectedCharacter(int characterSelectionNumber)
  {
    //Determine the index of the character the user chose. Return the index.
    if (characterSelectionNumber == 1)
    {
      //character 1's index is 0
      return 0;
    }
    else if (characterSelectionNumber == 2)
    {
      //character 2's index is 1
      return 1;
    }
    else if (characterSelectionNumber == 3)
    {
      //character 3's index is 2
      return 2;
    }
    else
    {
      //the number entered is invalid
      return -1;
    }

  }

  //MENU 2: Playing the Game
  static void GamePlayMenu()
  {
    //create a random number (either 1 or 2) to decide what who computer plays. 
    int number = randomNumber.Next(1,3);

    //Choose an index for the enemy's character which isn't the character the player chose
    //Ifhe player chooses Blossom, the computer must either be Bubbles or Buttercup
    if (selectedIndex == 0)
    {
      if (number == 1)
      {
        //if the random number is 1, the computer chooses Bubbles
        enemyIndex = 1;
      }
      else if (number == 2)
      {
        //if the random number is 2, the computer chooses Buttercup
        enemyIndex = 2;
      }
    }
    //If the player chooses Bubbles, the computer must either be Blossom or Buttercup
    else if (selectedIndex == 1)
    {
      if (number == 1)
      {
        //if the random number is 1, the computer chooses Blossom
        enemyIndex = 0;
      }
      else if (number == 2)
      {
        //if the random number is 2, the computer chooses Buttercup
        enemyIndex = 2;
      }
    }
    //If the player chooses Buttercup, the computer must either be Bubbles or Blossom
    else if (selectedIndex == 2)
    {
      if (number == 1)
      {
        //if the random number is 1, the computer chooses Blossom
        enemyIndex = 0;
      }
      else if (number == 2)
      {
        //if the random number is 2, the computer chooses Bubbles
        enemyIndex = 1;
      }
    }


    //Display who the enemy chose
    Console.WriteLine("Your enemy is " + names[enemyIndex] + "!");

    //Make the current health equal to max health to begin
    currentHealth[selectedIndex] = maxHealth[selectedIndex];
    currentHealth[enemyIndex] = maxHealth[enemyIndex];

    //store the user's choice of action
    string choice;

    //create a loop for the user to choose their gameplay actions
    do{

      //Display the battle info of both characters
      BattleInformationScreen(selectedIndex, enemyIndex);

      //Give the user their options of action
      Console.WriteLine("1. Normal Attack");
      Console.WriteLine("2. Heal");
      
      //The special attack choice is a different colour when it is unavailable
      if (recharge[selectedIndex] == true)
      {
        //the special attack is available - normal colour
        Console.WriteLine("3. Special Attack (takes 1 turn to recharge)");
      }
      else 
      //SPECIAL ATTACK is shown in different colour because it is unavailable
      {
        //The text becomes red
        Console.WriteLine("3. Special Attack (takes 1 turn to recharge)", Console.ForegroundColor = ConsoleColor.Red);
        //Change the colour back to white for the rest of the text
        Console.ForegroundColor = ConsoleColor.White;
      }

      Console.WriteLine("4. Forfeit");
      Console.WriteLine();

      //ask the user for their choice of action
      Console.Write("Action of choice: ");
      
      choice = Console.ReadLine();
      Console.WriteLine(); 

      //Determine what the user chooses to do.
      if (choice == "1")
      {
        //The player uses a normal attack. Display their action and how much damage they dealt.
        Console.WriteLine("You used NORMAL ATTACK! You dealt " + NormalAttack(normalAtkPwr[selectedIndex]) + " damage to your opponent.");

        //Adjust the enemy's health accordingly
        currentHealth[enemyIndex] = currentHealth[enemyIndex] - NormalAttack(normalAtkPwr[selectedIndex]);

        //The cooldown of special attack would be recharged if not already
        if (recharge[selectedIndex] == false)
        {
          recharge[selectedIndex] = true;
        }

        //After the player finishes their turn, it is the enemy's turn
        ComputerMove();

      }
      else if (choice == "2")
      {
        //The player heals themself. Display their action and how much they healed for.
        Console.WriteLine("You used HEAL! You healed for " + Healing(selectedIndex) + " health.");

        //adjust the player's health accordingly
        currentHealth[selectedIndex] = currentHealth[selectedIndex] + Healing(selectedIndex);

        //The cooldown of special attack would be recharged if not already
        if (recharge[selectedIndex] == false)
        {
          recharge[selectedIndex] = true;
        }

        //After the player finishes their turn, it is the enemy's turn
        ComputerMove();

      }
      else if (choice == "3")
      {
        //The player uses their special attack. It cannot be used for 1 turn after it is used once. 
        //If recharge is true, the move is available, but if recharge is false it is not available to use.
        //When the special attack is available for use:
        if (recharge[selectedIndex] == true)
        {
          //The player uses a special attack. Display their action and how much damage they dealt.
          Console.WriteLine("You used SPECIAL ATTACK! You dealt " + SpecialAttack(selectedIndex) + " damage to your opponent. This is on a 1 turn cooldown.");
    
          //adjust the enemy's health
          currentHealth[enemyIndex] = currentHealth[enemyIndex] - SpecialAttack(selectedIndex);

          //make the recharge false so that it will be unavailable for the next turn.
          recharge[selectedIndex] = false;

          //After the player finishes their turn, it is the enemy's turn
          ComputerMove();

        }
        //When recharge = false (special attack is on cooldown)
        else
        {
          //Tell the player the special attack can't be used until next turn.
          Console.WriteLine("SPECIAL ATTACK is on cooldown and will be available next turn. You dealt " + SpecialAttack(selectedIndex) + " damage.");

          //Since they have taken their turn without using the special attack, it will be available for next turn, so recharge = true now.
          recharge[selectedIndex] = true;

          //After the player finishes their turn, it is the enemy's turn
          ComputerMove();

        }
      }
      //The player inputs an invalid choice.
      else if (choice != "4")
      {
        //notify the user that they have inputted an invalid answer
        Console.WriteLine("Invalid choice. Try again.");
        Console.WriteLine();
      }


      //Check if anyone's health reaches 0 or below. If so, the game ends.
      if (currentHealth[selectedIndex] <= 0)
      {
        //print the final stats for the player to see 
        BattleInformationScreen(selectedIndex, enemyIndex);
        Console.WriteLine();

        //the player has reached 0 or below health and loses
        Console.WriteLine("Uh oh! You died O.O GAME OVER.");
        Console.Write("Try again? (y/n): ");

        //the player wants to retry
        if (Console.ReadLine() == "y")
        {
          //run the program again
          CharacterSelectionMenu();
        }
        //the player doesn't want to play again
        else if (Console.ReadLine() == "n")
        {
          Console.WriteLine("Well, thanks for playing! Till next time :)");
          return;
        }
        else
        //the player types something else
        {
          Console.WriteLine("UHHH what?? Guess that's a no...BYE!");
          return;
        }
      }
      //the enemy's health reaches zero or below
      else if (currentHealth[enemyIndex] <= 0)
      {
        //print the final stats for the player to see 
        BattleInformationScreen(selectedIndex, enemyIndex);
        Console.WriteLine();

        //the computer enemy has reached 0 health and loses
        Console.WriteLine("Hooray! You have won >:D!");
        Console.WriteLine("Try again? (y/n): ");

        //the player wants to retry
        if (Console.ReadLine() == "y")
        {
          //run the program again
          CharacterSelectionMenu();
        }
        //the player doesn't want to play again
        else if (Console.ReadLine() == "n")
        {
          Console.WriteLine("Well, thanks for playing! Till next time :)");
          //exit the program
          return;
        }
        else
        //the player types something else
        {
          //exit the program
          return;
        }
      }

    } while (choice != "4");

    //when the user chooses 4, they forfeit
    Console.WriteLine("FORFEITED!");

  }

  
  //2. Used when Normal Attack is used by either player (to reduce their opponent's health)
  static int NormalAttack(int attackPower)
  {
    //create and return random number for the normal attack power of the player
    attackPower = randomNumber.Next(20, attackPower + 1);
    return attackPower;
    
  }

  //3. Used when Special Attack is used by either player (to reduce opponent's health)
  static int SpecialAttack(int indexCharacter)
  {
    //create random number between 100 and the special attack power of the character ONLY if the special attack has been recharged
    if (recharge[indexCharacter] == true)
    {
      //the special attack is recharged
      //create an int to store how much damage the special attack does.
      int specialAttackDamage = randomNumber.Next(100, specialAtkPwr[indexCharacter]);

      //return the amount of damage dealt
      return specialAttackDamage;
    }
    //if the special attack was not recharged, return zero
    else
    {
      //The special attack has not been recharged. Return 0 damage dealt.
      return 0;
      
    }
  }

  //4. Used when Heal is used by either player in order to increase their own current health.
  static int Healing(int indexCharacter)
  {
    //create and store a random number for the healing power of the player
    int heal = randomNumber.Next(20, healPwr[indexCharacter]);

    //If the character's current health plus the heal value is greater than their max health, they cannot heal over their max health. 
    if (currentHealth[indexCharacter] + heal > maxHealth[indexCharacter])
    {
      return maxHealth[indexCharacter] - currentHealth[indexCharacter];
    }
    else
    {
      //otherwise they heal for the random number amount.
      return heal;
    }

  }


  //5. Displays battle information
  static void BattleInformationScreen(int indexPlayer, int indexComputer)
  {
    Console.WriteLine();
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");

    //identify the selectedIndex and enemyIndex
    selectedIndex = indexPlayer;
    enemyIndex = indexComputer;

    //Player information
    Console.WriteLine("Your Character: " + names[selectedIndex]);
    //Console.WriteLine(images[indexPlayer]);
    Console.WriteLine("Max. Health: " + maxHealth[selectedIndex]);
    Console.WriteLine("Current Health: " + currentHealth[selectedIndex]);

    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");

    //Enemy information
    Console.WriteLine("Enemy Character: " + names[enemyIndex]);
    //Console.WriteLine(images[enemyIndex]);
    Console.WriteLine("Max. Health: " + maxHealth[enemyIndex]);
    Console.WriteLine("Current Health: " + currentHealth[enemyIndex]);

    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");

  }

  //6. Select the enemy computer's move (Method 4 - medium intelligence + weighted probabilities)
  static void ComputerMove()
  {
    //if the computer's character has full/near full health, it will not heal
    if (currentHealth[enemyIndex] == maxHealth[enemyIndex] || currentHealth[enemyIndex] > maxHealth[enemyIndex] - 25)
    {
      //Decide if the computer will use a normal attack or special attack.
      //The computer will not use a special attack if it is on cooldown
      if (recharge[enemyIndex] == false)
      {
        //The special attack is on cooldown so the computer will use a normal attack instead. Display the events to the player.
        Console.WriteLine("Your enemy used NORMAL ATTACK! They dealt " + NormalAttack(normalAtkPwr[enemyIndex]) + " damage to you.");

        //adjust the player's health accordingly
        currentHealth[selectedIndex] = currentHealth[selectedIndex] - NormalAttack(normalAtkPwr[enemyIndex]);
      }
      //The computer's recharge is true - they can use their special attack
      else
      {
        //The computer uses the special attack because it is not on cooldown. Display the events to the player.
        Console.WriteLine("Your enemy used SPECIAL ATTACK! They dealt " + SpecialAttack(enemyIndex) + " damage to you.");

        //adjust the player's health accordingly
        currentHealth[selectedIndex] = currentHealth[selectedIndex] - SpecialAttack(enemyIndex);
      }

    }
    //Determine what to do if the player is low on health
    else if (currentHealth[selectedIndex] <= 120)
    {
      //If the special attack is available, use it.
      if (recharge[enemyIndex] == true)
      {
        //The computer uses the special attack. Display the events to the player.
        Console.WriteLine("Your enemy used SPECIAL ATTACK! They dealt " + SpecialAttack(enemyIndex) + " damage to you.");

        //adjust the player's health accordingly
        currentHealth[selectedIndex] = currentHealth[selectedIndex] - SpecialAttack(enemyIndex);
      }
      else
      {
        //The special attack is unavailable. Use weighted probabilities to determine the computer's move.
        WeightedProbabilities();
      }
    }
    //Heal if the computer is low on health.
    else if (currentHealth[enemyIndex] <= 160)
    {
      //Since special attacks do at least 100 damage, the computer will heal to try to prevent death.
      //Display events to the player.
      Console.WriteLine("The enemy used HEAL! They healed for " +  Healing(enemyIndex) + " health.");

      //Adjust the computer character's health.
      currentHealth[enemyIndex] = currentHealth[enemyIndex] + Healing(enemyIndex);

    }
    //Otherwise, it uses weighted probabilities (method 2) to determine it's move
    else
    {
      WeightedProbabilities();
    }

  }

  //This subprogram is for the Weighted Probabilities (method 2) to determine the computer's move.
  static void WeightedProbabilities()
  {
    //Create a random number.
    int number = randomNumber.Next(0,100);

    //If the random number is between 0-49, use a normal attack. 
    if (number <= 49)
    {
      //Display the events to the player.
      Console.WriteLine("The enemy used NORMAL ATTACK! They dealt " +  NormalAttack(normalAtkPwr[enemyIndex]) + " damage to you.");
      //adjust the player's health accordingly
      currentHealth[selectedIndex] = currentHealth[selectedIndex] - NormalAttack(normalAtkPwr[enemyIndex]);
     }
    //If the number is between 50-79, use a special attack.
    else if (number >= 50 && number <= 79)
    {
      //Display the events to the player.
      Console.WriteLine("The enemy used SPECIAL ATTACK! They dealt " +  SpecialAttack(enemyIndex) + " damage to you.");
      //adjust the player's health accordingly
      currentHealth[selectedIndex] = currentHealth[selectedIndex] - SpecialAttack(enemyIndex);
    }
    // If the number is between 80-99, heal.
    else if (number >= 80 && number <= 99)
    {
      //Display the events to the player.
      Console.WriteLine("The enemy used HEAL! They healed for " +  Healing(enemyIndex) + " health.");
      //adjust the enemy's health accordingly
      currentHealth[enemyIndex] = currentHealth[enemyIndex] + Healing(enemyIndex);
    }

  }

}