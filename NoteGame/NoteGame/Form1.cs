using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteGame
{
    public partial class Form1 : Form
    {
        Random rnd;
        int scene = 1;
        int chance;
        int ladder = 0;
        bool front, back, /*ladderBreak,*/ contFlee, hatch;
        string prompt = "What do you do?";
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            chance = rnd.Next(1, 101);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            aLabel.Text = "";
            bLabel.Text = "";
            cLabel.Text = "";

            if (e.KeyCode == Keys.A)
            {
                switch (scene)
                {
                    case 1:
                        outcomeLabel.Text = "The note reads: We are discovered, flee immediately.";
                        outputLabel.Text = prompt;
                        scene = 2;
                        break;
                    case 2:
                        outcomeLabel.Text = "A black SUV screeches around the corner to your left down the street.";
                        front = true;
                        back = false;
                        scene = 3;
                        break;
                    case 3:
                        if (front == true)
                        {
                            //restart button
                            outcomeLabel.Text = "The SUV speeds down to you, the window rolls down and a gun barrel is revealed. Darkness.";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                        }
                        else if (back == true)
                        {
                            outcomeLabel.Text = "You reach the top and look back, the man is climbing the ladder after you.";
                            scene = 4;
                        }
                        break;
                    case 4:
                        if (front == true)
                        {
                            outcomeLabel.Text = "You hear men yelling from the shop, you turn and see them running towards you, firearms in hand. Citizens panic and create a temporary diversion.";
                            outputLabel.Text = "";
                            scene = 5;
                        }
                        else if (back == true)
                        {
                            if (chance >= 1 && chance < 31)
                            {
                                outcomeLabel.Text = "Fail, turn and hop to the next rooftop, the man in close pursuit";
                                ladder = 2;
                                scene = 5;
                            }
                            else if (chance >= 31 && chance < 101)
                            {
                                outcomeLabel.Text = "Succeed, the man falls off, knocking him unconcious";
                                //ladderBreak = true;
                                ladder = 1;
                                scene = 5;
                            }
                        }
                        break;
                    case 5:                                                                             //SCENARIOS UNREACHABLE
                        if (front == true && chance >= 1 && chance <= 50)
                        {
                            //restart button
                            outcomeLabel.Text = "Escape with the crowd to safety. YOU WIN!";
                            outcomeLabel.BackColor = Color.Gold;
                            outcomeLabel.ForeColor = Color.White;
                        }
                        else if (back == true && chance >= 51 && chance <= 101)
                        {
                            //restart button
                            outcomeLabel.Text = "You see a glare in a window from a building across the street. BANG.";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                        }
                        else if (back == true && ladder == 0)
                        {
                            outcomeLabel.Text = "You land in an empty office floor, a custodian closet beside you and a stairwell nearby";
                            scene = 6;
                        }
                        break;
                }
            }
            if (e.KeyCode == Keys.B)
            {
                switch (scene)
                {
                    case 1:
                        //restart button
                        outcomeLabel.Text = "You hear tires screeching outside. The pattering of dress shoes enter the shop. You feel a knock to the head. Darkness.";
                        outcomeLabel.ForeColor = Color.White;
                        outcomeLabel.BackColor = Color.Red;
                        outputLabel.Text = "";
                        break;
                    case 2:
                        //restart button
                        outcomeLabel.Text = "You hear tires screeching outside. The pattering of dress shoes enter the shop. You feel a knock to the head. Darkness.";
                        outcomeLabel.ForeColor = Color.White;
                        outcomeLabel.BackColor = Color.Red;
                        outputLabel.Text = "";
                        break;
                    case 3:
                        if (front == true)
                        {
                            outcomeLabel.Text = "You hide underneath the picnic bench.";  
                            outputLabel.Text = "The SUV stops in front of the shop, men in suits rush into the building.";
                            scene = 4;
                        }
                        else if (back == true)
                        {
                            //restart button
                            outcomeLabel.Text = "The man pulls a gun from his inner jacket and aims. Darkness.";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                        }
                        break;
                    case 4:
                        if (front == true)
                        {
                            //restart button
                            outcomeLabel.Text = "The men come out of the shop and begin to search the area. The men quickly see you and drag you to the SUV. They put a bag over your head. Darkness";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                            outputLabel.Text = "";
                        }
                        else if (back == true && ladder == 2)
                        {
                            outcomeLabel.Text = "You look behind you. The man says to his earpiece \"target in open sight\" You hear a loud gunshot. Darkness";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                        }
                        else if (back == true && ladder == 0)
                        {
                            outcomeLabel.Text = "There's a hatch on the roof, there's nowhere else to go.";
                            hatch = true;
                            scene = 5;
                        }                        
                        break;
                    case 5:
                        if (front == true && chance >= 1 && chance <= 30)
                        {
                            //restart button
                            outcomeLabel.Text = "Hide with the restaurant staff, you're never found. YOU WIN!";
                            outcomeLabel.BackColor = Color.Gold;
                            outcomeLabel.ForeColor = Color.White;
                        }
                        else if (back == true && chance >= 31 && chance <= 101)
                        {
                            //restart button
                            outcomeLabel.Text = "The men in suits follow you to the restaurant and take you into their custody.";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                        }
                        else if (back == true && hatch == true)
                        {
                            outcomeLabel.Text = "Open the roof hatch and drop in"; //60/40
                        }
                        break;
                }
            }
            if (e.KeyCode == Keys.C)
            {
                switch (scene)
                {
                    case 1:                                           
                        break;
                    case 2:
                        outcomeLabel.Text = "A man in a suit down the alley talks into an earpiece and moves quickly towards you.";
                        outputLabel.Text = prompt;
                        back = true;
                        front = false;
                        scene = 3;
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            }

            //SCENE OUTPUT AND CHOICES
            switch (scene)
            {
                case 1:
                    break;
                case 2:
                    aLabel.Text = "Run out the front door.";
                    bLabel.Text = "Ignore the note. Crazy nonsense.";
                    cLabel.Text = "Run out the back door to the alley.";
                    break;
                case 3:
                    if (front == true)
                    {
                        outputLabel.Text = "";
                        aLabel.Text = "Run in the opposite direction down the street.";
                        bLabel.Text = "Duck under a picnic bench nearby.";
                        cLabel.Text = "";
                    }
                    else if (back == true)
                    {
                        outputLabel.Text = "";
                        aLabel.Text = "Climb a ladder to the shop's rooftop.";
                        bLabel.Text = "Run down the alley away from the man.";
                        cLabel.Text = "";
                    }                   
                    break;
                case 4:
                    if (front == true)
                    {
                        aLabel.Text = "Leave the bench, running down the street.";
                        bLabel.Text = "Stay under the bench.";
                        cLabel.Text = "";
                    }
                    else if (back == true)
                    {
                        aLabel.Text = "Try to shake the ladder loose off the wall."; //30/70
                        bLabel.Text = "Continue to flee, hop to the next rooftop.";
                        cLabel.Text = "";
                        hatch = true;
                    }
                    break;
                case 5:
                    if (front == true)
                    {
                        aLabel.Text = "Take a man's ball cap and put it on and run with the crowd."; //50/50
                        bLabel.Text = "Run into a nearby restraunt."; //30/70
                        cLabel.Text = "";
                    }
                    else if (back == true && ladder == 0)   //ladderchange
                    {
                        aLabel.Text = "Open the roof hatch and drop in"; //60/40 
                        bLabel.Text = "";
                        cLabel.Text = "";
                    }
                    else if (back == true && ladder == 1)
                    {
                        aLabel.Text = "Run and jump to the next rooftop";
                    }
                    break;
            }
        }
    }
}
// LEFT OFF ON CASE 6                       