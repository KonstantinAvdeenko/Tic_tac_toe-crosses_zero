This program in the C# programming language, implements the game "Tic-tac-toe" in the user - AI mode,
where the AI ​​uses a minimax strategy of thinking over a move,
based on the current situation on the playing field of the game "Tic-tac-toe".

The rules of the game are that it is necessary to build a line of three crosses or zeroes in any direction.
and in any way - horizontally, vertically or diagonally. Accordingly, your opponent is a computer
should build a similar line faster than you or not let you build such a line.
The game begins with the fact that anywhere in the playing field put a cross or a toe, depending on
who is first to make a move, your opponent puts a cross or a toe, and so on until a line is drawn
from crosses or zeros. In this program to win, you must first make a line.
The player who goes first always plays with crosses.

In order to more convenient design, configuration, and separation of individual executable operations,
The game "Tic-tac-toe" is built on modules, which in turn are built on classes and methods
interacting with each other. Using modules, classes and methods gives you an improved understanding of the code,
which means setting and subsequent modification of the source code of the program. This game consists of the following modules:
1) Program - the main entry point into the game application.
2) Form1 - the main form of the game application, the whole game takes place in this form.
3) AssemblyInfo - module of parameters of assembly and identification of the type library of COM components.
4) Resources.Designer - created automatically by the StronglyTypedResourceBuilder class
using Visual Studio.
5) Settings.Designers - created automatically by the StronglyTypedResourceBuilder class using Visual Studio,
contains settings sync features.

Program Module is the main entry point into the game application and launches the main form of the Form1 application,
as well as support functions for setting up Resources.Designer and Settings.Designers.

The main form module Form1 contains the only main form class public partial class Form1,
which consists of the following main function-returning methods:
1) private void button1_Click - is responsible for checking who will make the move first by the user's choice;
2) private void panel1_Paint - divides the playing field into coordinate cells;
3) private void panel1_MouseClick - is responsible for the game "Tic-tac-toe" by the user,
notifies if the user is trying to use a busy cell;
4) private void hod1 - the first move for the AI, if possible, to the center of the playing field, then according to the situation;
5) private void hod - check for the ability to make a move, draw or win;
6) private void paint - the check will be played by AI crosses or zeros;
7) private void winner - in case of winning, the winning combination is crossed out;
8) private void pobeda - AI attack, attempt to win if there is a possibility in case AI
makes a move first;
9) private void zachita - protection of AI, so as not to lose, if AI makes the first move;
10) private void krestiki - AI tactics if he makes the first move;
11) private void nichia - if the playing field is filled, but there is no winner, then a draw;
12) private void newgame - the beginning of a new game;
13) private void ugol - protection of AI when the user walks first;
14) private void napad - an AI attack when the user first walks.

Instructions for the game "Tic-tac-toe"
Just start the game "Tic-tac-toe", choose which player will make the move first and start the game.
To start the game again, clear the playing field, choose who will make the first move and start the game.