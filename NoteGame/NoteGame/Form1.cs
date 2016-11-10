using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Media;
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
        int ladder = 0;                         //For scene requirements
        bool front, back, hatch, hatchSafe;     //For scene requirements
        string prompt = "What do you do?";       

        //Restart function
        private void restartButton_Click(object sender, EventArgs e)
        {
            scene = 1;
            ladder = 0;
            outputLabel.Text = "You're sitting in a coffee shop when a stranger walks by and drops a folded note on your table.";
            aLabel.Text = "Open the note and read it.";
            bLabel.Text = "Brush the note off your table.";
            cLabel.Text = "";
            outcomeLabel.Text = "";
            outcomeLabel.BackColor = Color.Transparent;
            outcomeLabel.ForeColor = Color.Black;
            restartButton.Visible = false;
            restartButton.Enabled = false;            
        }
        
        //Keep output box filled if empty
        private void sceneCheckTimer_Tick(object sender, EventArgs e)
        {
            if (outputLabel.Text == "" && restartButton.Visible == false)
            {
                outputLabel.Text = prompt;
            }
        }    
            
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            chance = rnd.Next(1, 11);          
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            outputLabel.Text = "";
            aLabel.Text = "";
            bLabel.Text = "";
            cLabel.Text = "";

            if (e.KeyCode == Keys.A)    //Scene choice A
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
                            restartButton.Visible = true;
                            outcomeLabel.Text = "The SUV speeds down to you, the window rolls down and a gun barrel is revealed and you're shot in the street";
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
                            if (chance >= 1 && chance < 4)
                            {
                                outcomeLabel.Text = "Fail, turn and hop to the next rooftop, the man in close pursuit";
                                ladder = 2;
                                scene = 5;
                            }
                            else if (chance >= 4 && chance < 11)
                            {
                                outcomeLabel.Text = "Succeed, the man falls off, knocking him unconcious";
                                ladder = 1;
                                scene = 5;
                            }
                        }
                        break;
                    case 5:                                                                             
                        if (front == true && chance >= 1 && chance < 6)
                        {
                            restartButton.Visible = true;
                            outcomeLabel.Text = "Escape with the crowd to safety. YOU WIN!";
                            outcomeLabel.BackColor = Color.Gold;
                            outcomeLabel.ForeColor = Color.White;
                        }
                        else if (front == true && chance >= 6 && chance < 11)
                        {
                            restartButton.Visible = true;
                            outcomeLabel.Text = "You see a glare in a window from a building across the street. BANG.";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                        }
                        else if (back == true && ladder == 0)
                        {
                            outcomeLabel.Text = "You land in an empty office floor, a custodian closet beside you and a stairwell nearby";
                            scene = 6;
                        }
                        else if (back == true && ladder == 1)
                        {
                            outcomeLabel.Text = "Run and jump to the next rooftop.";
                            outputLabel.Text = "There's a hatch on the roof, there's nowhere else to go.";
                            scene = 6;
                        }
                        else if (back == true && ladder == 2)
                        {
                            restartButton.Visible = true;
                            outcomeLabel.Text = "The man says to his earpiece \"target in open sight on the rooftop\" A sniper fires and kills you.";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                        }
                        break;
                    case 6:
                        if (back == true && ladder == 0)
                        {
                            outcomeLabel.Text = "You land in an empty office floor, a custodian closet beside you and a stairwell nearby.";
                            scene = 7;
                        }
                        else if (back == true && ladder == 1)
                        {
                            if (hatchSafe == true)
                            {
                                hatchSafe = false;
                                ladder = 0;
                                goto case 6;
                            }
                            else
                            {
                                restartButton.Visible = true;
                                outcomeLabel.Text = "You fall down a lot further than expected and break your legs.";
                                
                                outcomeLabel.ForeColor = Color.White;
                                outcomeLabel.BackColor = Color.Red;
                            }
                        }
                        break;
                    case 7:
                        if (back == true && ladder == 0 || back == true && ladder == 1)
                        {
                            restartButton.Visible = true;
                            outcomeLabel.Text = "You hide for hours and are never found!";
                            outcomeLabel.BackColor = Color.Gold;
                            outcomeLabel.ForeColor = Color.White;
                        }
                        break;
                }
            }
            if (e.KeyCode == Keys.B)    //Scene choice B
            {
                switch (scene)
                {
                    case 1:
                        restartButton.Visible = true;
                        outcomeLabel.Text = "You hear tires screeching outside. The pattering of dress shoes enter the shop. You feel a knock to the head and fall unconscious.";
                        outcomeLabel.ForeColor = Color.White;
                        outcomeLabel.BackColor = Color.Red;
                        outputLabel.Text = "";
                        break;
                    case 2:
                        restartButton.Visible = true;
                        outcomeLabel.Text = "You hear tires screeching outside. The pattering of dress shoes enter the shop. You feel a knock to the head and fall unconscious.";
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
                            restartButton.Visible = true;
                            outcomeLabel.Text = "The man pulls a gun from his inner jacket and shoots you in the back.";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                        }
                        break;
                    case 4:
                        if (front == true)
                        {
                            restartButton.Visible = true;
                            outcomeLabel.Text = "The men come out of the shop and begin to search the area. The men quickly see you and drag you to the SUV. They put a bag over your head. Darkness";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                            outputLabel.Text = "";
                        }
                        else if (back == true && ladder == 2)
                        {
                            outcomeLabel.Text = "The man says to his earpiece \"target in open sight on the rooftop\" A sniper fires and kills you.";
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
                        if (front == true && chance >= 1 && chance < 4)
                        {
                            restartButton.Visible = true;
                            outcomeLabel.Text = "Hide with the restaurant staff, you're never found. YOU WIN!";
                            outcomeLabel.BackColor = Color.Gold;
                            outcomeLabel.ForeColor = Color.White;
                        }
                        else if (back == true && chance >= 4 && chance < 11)
                        {
                            restartButton.Visible = true;
                            outcomeLabel.Text = "The men in suits follow you to the restaurant and take you into their custody.";
                            outcomeLabel.ForeColor = Color.White;
                            outcomeLabel.BackColor = Color.Red;
                        }
                        else if (back == true && hatch == true)
                        {
                            outcomeLabel.Text = "Open the roof hatch and drop in"; //60/40
                        }
                        break;
                    case 6:
                        if (back == true && ladder == 1)
                        {
                            outcomeLabel.Text = "The hatch is a safe drop down.";
                            aLabel.Text = "Open the hatch and jump down.";
                            bLabel.Text = "";
                            hatchSafe = true;
                           
                        }
                        break;
                    case 7:
                        if (back == true && ladder == 0 || back == true && ladder == 1)
                        {
                            restartButton.Visible = true;
                            outcomeLabel.Text = "A suit is waiting for you in there, you hear a deafening bang and see a gun in his hand.";
                            outcomeLabel.BackColor = Color.Red;
                            outcomeLabel.ForeColor = Color.White;
                        }
                        break;
                }
            }
            if (e.KeyCode == Keys.C)    //Scene choice C
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
                    case 6:
                        break;
                    case 7:
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
                    else if (back == true && ladder == 0)
                    {
                        aLabel.Text = "Open the roof hatch and drop in"; //60/40 
                        bLabel.Text = "";
                        cLabel.Text = "";
                    }
                    else if (back == true && ladder == 1)
                    {
                        aLabel.Text = "Run and jump to the next rooftop";
                        bLabel.Text = "";
                        cLabel.Text = "";
                    }
                    else if (back == true && ladder == 2)
                    {
                        outcomeLabel.Text = "";
                        outcomeLabel.ForeColor = Color.White;
                        outcomeLabel.BackColor = Color.Red;
                    }
                    break;
                case 6:
                    if (front == true)
                    {
                        aLabel.Text = "Error"; 
                        bLabel.Text = "";
                        cLabel.Text = "";
                    }
                    else if (back == true && ladder == 0) 
                    {
                        aLabel.Text = "Open the roof hatch and drop in"; //60/40 
                        bLabel.Text = "";
                        cLabel.Text = "";
                    }
                    else if (back == true && ladder == 1)
                    {
                        aLabel.Text = "Open the hatch and jump down.";
                        bLabel.Text = "Open the hatch and inspect the drop.";
                        cLabel.Text = "";
                    }
                    break;
                case 7:
                    if (back == true && ladder == 0)
                    {
                        aLabel.Text = "Hide in the closet.";
                        bLabel.Text = "Run into the stairwell.";
                    }
                    break;
            }
        }
    }
}                 