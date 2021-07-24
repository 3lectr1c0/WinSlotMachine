using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SlotMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // use this to set initial balance 

        public double balance = Properties.Settings.Default.Money;

        // creates random variables 
        Random slot1rand = new Random();
        Random slot2rand = new Random();
        Random slot3rand = new Random();

        // loads images to variables

        Bitmap lemon = Properties.Resources.lemon;
        Bitmap banana = Properties.Resources.banana;
        Bitmap melon = Properties.Resources.melon;
        Bitmap orange = Properties.Resources.orange;
        Bitmap plum = Properties.Resources.plum;
        Bitmap cherry = Properties.Resources.cherry;
        Bitmap bar = Properties.Resources.bar;
        Bitmap seven = Properties.Resources.seven;
        Bitmap win = Properties.Resources.win;
        Bitmap lightoff = Properties.Resources.lightoff;
        Bitmap lighton = Properties.Resources.lighton;

        // Which slot gets bonus
        int slotnum;


        // Hold Toggle Bools
        bool hold1toggle = false;
        bool hold2toggle = false;
        bool hold3toggle = false;

        // Check if bonuses active

        bool ishold = false;
        bool isnudge = false;

        // Defines slot variables
        int slot1;
        int slot2;
        int slot3;

        private void Form1_Load(object sender, EventArgs e)
        {
            // loads initial balance
            balancebox.Text = Properties.Settings.Default.Currency + Properties.Settings.Default.Money;


        }

        private void Spinbutton_Click(object sender, EventArgs e)
        {

            if (balance < 2)
            {
                goto gotoend;
            }

            // takes payment
            balance = balance - 2;
            balancebox.Text = Properties.Settings.Default.Currency + balance;

            // Saves Money
            Properties.Settings.Default["Money"] = balance;
            Properties.Settings.Default.Save();

            // generates slot random numbers and holds when needed

            // slot 1 hold
            if (hold1toggle == false)
            {
                // slot 1 rand
                slot1 = slot1rand.Next(1, 10);
            }

            // slot 2 hold
            if (hold2toggle == false)
            {
                // slot 2 rand
                slot2 = slot2rand.Next(1, 10);
            }

            // slot 3 hold
            if (hold3toggle == false)
            {
                // slot 3 rand
                slot3 = slot3rand.Next(1, 10);
            }


            // reset bonus
            if (ishold == true)
            {
                ishold = false;
                hold1toggle = false;
                hold2toggle = false;
                hold3toggle = false;
                Slot1light.Image = lightoff;
                Slot2light.Image = lightoff;
                Slot3light.Image = lightoff;
                Holdlight.Image = lightoff;
            }

            // reset nudge
            if (isnudge == true)
            {
                isnudge = false;
                Nudgelight.Image = lightoff;
                Slot1light.Image = lightoff;
                Slot2light.Image = lightoff;
                Slot3light.Image = lightoff;
            }


            // checks if slot matches
            if (slot1 == slot2)
                if (slot2 == slot3)
                {
                    // switches based on win number
                    switch (slot2)
                    {
                        // lemon win
                        case 1:
                            // adds and updates balance
                            balance = balance + 0.25;
                            balancebox.Text = Properties.Settings.Default.Currency + balance;
                            goto jumpsetimage;

                        // banana win
                        case 2:
                            // adds and updates balance
                            balance = balance + 1;
                            balancebox.Text = Properties.Settings.Default.Currency + balance;
                            goto jumpsetimage;

                        // melon win
                        case 3:
                            // adds and updates balance
                            balance = balance + 2.50;
                            balancebox.Text = Properties.Settings.Default.Currency + balance;
                            goto jumpsetimage;

                        // orange win
                        case 4:
                            // adds and updates balance
                            balance = balance + 5;
                            balancebox.Text = Properties.Settings.Default.Currency + balance;
                            goto jumpsetimage;

                        // plum win
                        case 5:
                            // adds and updates balance
                            balance = balance + 7.25;
                            balancebox.Text = Properties.Settings.Default.Currency + balance;
                            goto jumpsetimage;

                        // cherry win
                        case 6:
                            // adds and updates balance
                            balance = balance + 10;
                            balancebox.Text = Properties.Settings.Default.Currency + balance;
                            goto jumpsetimage;

                        // bar win
                        case 7:
                            // adds and updates balance
                            balance = balance + 15;
                            balancebox.Text = Properties.Settings.Default.Currency + balance;
                            goto jumpsetimage;

                        // seven win
                        case 8:
                            // adds and updates balance
                            balance = balance + 23.25;
                            balancebox.Text = Properties.Settings.Default.Currency + balance;
                            goto jumpsetimage;

                        // win win (woohoo)
                        case 9:
                            // adds and updates balance
                            balance = balance + 100;
                            balancebox.Text = Properties.Settings.Default.Currency + balance;
                            goto jumpsetimage;
                    }

                }


            // wins jump to here

            jumpsetimage:

            // Saves Money
            Properties.Settings.Default["Money"] = balance;
            Properties.Settings.Default.Save();

            switch (slot1)
            {
                // slot 1 image to lemon
                case 1:
                    Slot1.Image = lemon;
                    goto jumpsetimage2;

                // slot 1 image to banana
                case 2:
                    Slot1.Image = banana;
                    goto jumpsetimage2;

                // slot 1 image to melon
                case 3:
                    Slot1.Image = melon;
                    goto jumpsetimage2;

                // slot 1 image to orange
                case 4:
                    Slot1.Image = orange;
                    goto jumpsetimage2;

                // slot 1 image to plum
                case 5:
                    Slot1.Image = plum;
                    goto jumpsetimage2;

                // slot 1 image to cherry
                case 6:
                    Slot1.Image = cherry;
                    goto jumpsetimage2;

                // slot 1 image to bar
                case 7:
                    Slot1.Image = bar;
                    goto jumpsetimage2;

                // slot 1 image to seven
                case 8:
                    Slot1.Image = seven;
                    goto jumpsetimage2;

                // slot 1 image to win
                case 9:
                    Slot1.Image = win;
                    goto jumpsetimage2;
            }

        jumpsetimage2:;


            switch (slot2)
            {
                // slot 2 image to lemon
                case 1:
                    Slot2.Image = lemon;
                    goto jumpsetimage3;

                // slot 2 image to banana
                case 2:
                    Slot2.Image = banana;
                    goto jumpsetimage3;

                // slot 2 image to melon
                case 3:
                    Slot2.Image = melon;
                    goto jumpsetimage3;

                // slot 2 image to orange
                case 4:
                    Slot2.Image = orange;
                    goto jumpsetimage3;

                // slot 2 image to plum
                case 5:
                    Slot2.Image = plum;
                    goto jumpsetimage3;

                // slot 2 image to cherry
                case 6:
                    Slot2.Image = cherry;
                    goto jumpsetimage3;

                // slot 2 image to bar
                case 7:
                    Slot2.Image = bar;
                    goto jumpsetimage3;

                // slot 2 image to seven
                case 8:
                    Slot2.Image = seven;
                    goto jumpsetimage3;

                // slot 2 image to win
                case 9:
                    Slot2.Image = win;
                    goto jumpsetimage3;
            }

        jumpsetimage3:

            switch (slot3)
            {
                // slot 3 image to lemon
                case 1:
                    Slot3.Image = lemon;
                    goto hold;

                // slot 3 image to banana
                case 2:
                    Slot3.Image = banana;
                    goto hold;

                // slot 3 image to melon
                case 3:
                    Slot3.Image = melon;
                    goto hold;

                // slot 3 image to orange
                case 4:
                    Slot3.Image = orange;
                    goto hold;

                // slot 3 image to plum
                case 5:
                    Slot3.Image = plum;
                    goto hold;

                // slot 3 image to cherry
                case 6:
                    Slot3.Image = cherry;
                    goto hold;

                // slot 3 image to bar
                case 7:
                    Slot3.Image = bar;
                    goto hold;

                // slot 3 image to seven
                case 8:
                    Slot3.Image = seven;
                    goto hold;

                // slot 3 image to win
                case 9:
                    Slot3.Image = win;
                    goto hold;
            }

        hold:

            // picks a slot
            Random slotrand = new Random();
            slotnum = slotrand.Next(1, 4);

            // Chance of getting bonus
            Random bonusrand = new Random();
            int bonus = bonusrand.Next(1, 16);

            // picks which bonus should be used
            Random bonuspickrand = new Random();
            int bonuspick = bonuspickrand.Next(1, 3);


            // Value to award bonus
            if (bonus == 10)
            {
                // Choses bonus type
                switch (bonuspick)
                {
                    case 1:
                        Holdlight.Image = lighton;
                        ishold = true;

                        switch (slotnum)
                        {
                            case 1:
                                Slot1light.Image = lighton;
                                break;

                            case 2:
                                Slot2light.Image = lighton;
                                break;

                            case 3:
                                Slot3light.Image = lighton;
                                break;
                        }
                        break;


                    case 2:
                        // Nudge
                        Nudgelight.Image = lighton;
                        isnudge = true;
                        switch (slotnum)
                        {
                            case 1:
                                Slot1light.Image = lighton;
                                break;

                            case 2:
                                Slot2light.Image = lighton;
                                break;

                            case 3:
                                Slot3light.Image = lighton;
                                break;
                        }
                        break;


                }




            }


        gotoend:;
        }

        private void Holdbutton_Click(object sender, EventArgs e)
        {
            if (ishold == true)
            {
                Holdlight.Image = lightoff;
                switch (slotnum)
                {
                    case 1:
                        hold1toggle = true;
                        break;

                    case 2:
                        hold2toggle = true;
                        break;

                    case 3:
                        hold3toggle = true;
                        break;
                }
            }
        }

        private void Nudgebutton_Click(object sender, EventArgs e)
        {
            if (isnudge == true)
            {
                Nudgelight.Image = lightoff;
                switch (slotnum)
                {
                    case 1:
                        slot1++;
                        if (slot1 > 9)
                        {
                            slot1 = 1;
                        }
                        break;

                    case 2:
                        slot2++;
                        if (slot2 > 9)
                        {
                            slot2 = 1;
                        }
                        break;

                    case 3:
                        slot3++;
                        if (slot3 > 9)
                        {
                            slot3 = 1;
                        }
                        break;

                }

                // checks if slot matches
                if (slot1 == slot2)
                    if (slot2 == slot3)
                    {
                        // switches based on win number
                        switch (slot2)
                        {
                            // lemon win
                            case 1:
                                // adds and updates balance
                                balance = balance + 0.25;
                                balancebox.Text = Properties.Settings.Default.Currency + balance;
                                goto jumpsetimage;

                            // banana win
                            case 2:
                                // adds and updates balance
                                balance = balance + 1;
                                balancebox.Text = Properties.Settings.Default.Currency + balance;
                                goto jumpsetimage;

                            // melon win
                            case 3:
                                // adds and updates balance
                                balance = balance + 2.50;
                                balancebox.Text = Properties.Settings.Default.Currency + balance;
                                goto jumpsetimage;

                            // orange win
                            case 4:
                                // adds and updates balance
                                balance = balance + 5;
                                balancebox.Text = Properties.Settings.Default.Currency + balance;
                                goto jumpsetimage;

                            // plum win
                            case 5:
                                // adds and updates balance
                                balance = balance + 7.25;
                                balancebox.Text = Properties.Settings.Default.Currency + balance;
                                goto jumpsetimage;

                            // cherry win
                            case 6:
                                // adds and updates balance
                                balance = balance + 10;
                                balancebox.Text = Properties.Settings.Default.Currency + balance;
                                goto jumpsetimage;

                            // bar win
                            case 7:
                                // adds and updates balance
                                balance = balance + 15;
                                balancebox.Text = Properties.Settings.Default.Currency + balance;
                                goto jumpsetimage;

                            // seven win
                            case 8:
                                // adds and updates balance
                                balance = balance + 23.25;
                                balancebox.Text = Properties.Settings.Default.Currency + balance;
                                goto jumpsetimage;

                            // win win (woohoo)
                            case 9:
                                // adds and updates balance
                                balance = balance + 100;
                                balancebox.Text = Properties.Settings.Default.Currency + balance;
                                goto jumpsetimage;
                        }

                    }


                // wins jump to here

                jumpsetimage:

                // Saves Money
                Properties.Settings.Default["Money"] = balance;
                Properties.Settings.Default.Save();

                switch (slot1)
                {
                    // slot 1 image to lemon
                    case 1:
                        Slot1.Image = lemon;
                        goto jumpsetimage2;

                    // slot 1 image to banana
                    case 2:
                        Slot1.Image = banana;
                        goto jumpsetimage2;

                    // slot 1 image to melon
                    case 3:
                        Slot1.Image = melon;
                        goto jumpsetimage2;

                    // slot 1 image to orange
                    case 4:
                        Slot1.Image = orange;
                        goto jumpsetimage2;

                    // slot 1 image to plum
                    case 5:
                        Slot1.Image = plum;
                        goto jumpsetimage2;

                    // slot 1 image to cherry
                    case 6:
                        Slot1.Image = cherry;
                        goto jumpsetimage2;

                    // slot 1 image to bar
                    case 7:
                        Slot1.Image = bar;
                        goto jumpsetimage2;

                    // slot 1 image to seven
                    case 8:
                        Slot1.Image = seven;
                        goto jumpsetimage2;

                    // slot 1 image to win
                    case 9:
                        Slot1.Image = win;
                        goto jumpsetimage2;
                }

            jumpsetimage2:;


                switch (slot2)
                {
                    // slot 2 image to lemon
                    case 1:
                        Slot2.Image = lemon;
                        goto jumpsetimage3;

                    // slot 2 image to banana
                    case 2:
                        Slot2.Image = banana;
                        goto jumpsetimage3;

                    // slot 2 image to melon
                    case 3:
                        Slot2.Image = melon;
                        goto jumpsetimage3;

                    // slot 2 image to orange
                    case 4:
                        Slot2.Image = orange;
                        goto jumpsetimage3;

                    // slot 2 image to plum
                    case 5:
                        Slot2.Image = plum;
                        goto jumpsetimage3;

                    // slot 2 image to cherry
                    case 6:
                        Slot2.Image = cherry;
                        goto jumpsetimage3;

                    // slot 2 image to bar
                    case 7:
                        Slot2.Image = bar;
                        goto jumpsetimage3;

                    // slot 2 image to seven
                    case 8:
                        Slot2.Image = seven;
                        goto jumpsetimage3;

                    // slot 2 image to win
                    case 9:
                        Slot2.Image = win;
                        goto jumpsetimage3;
                }

            jumpsetimage3:;

                switch (slot3)
                {
                    // slot 3 image to lemon
                    case 1:
                        Slot3.Image = lemon;
                        break;

                    // slot 3 image to banana
                    case 2:
                        Slot3.Image = banana;
                        break;

                    // slot 3 image to melon
                    case 3:
                        Slot3.Image = melon;
                        break;

                    // slot 3 image to orange
                    case 4:
                        Slot3.Image = orange;
                        break;

                    // slot 3 image to plum
                    case 5:
                        Slot3.Image = plum;
                        break;

                    // slot 3 image to cherry
                    case 6:
                        Slot3.Image = cherry;
                        break;

                    // slot 3 image to bar
                    case 7:
                        Slot3.Image = bar;
                        break;

                    // slot 3 image to seven
                    case 8:
                        Slot3.Image = seven;
                        break;

                    // slot 3 image to win
                    case 9:
                        Slot3.Image = win;
                        break;
                }

                // resets nudge
                isnudge = false;
                Nudgelight.Image = lightoff;
                Slot1light.Image = lightoff;
                Slot2light.Image = lightoff;
                Slot3light.Image = lightoff;

            }
        }
        // resets slot machine and balance
        private void resetbutton_Click(object sender, EventArgs e)
        {
            balance = 150;
            // Saves Money
            Properties.Settings.Default["Money"] = balance;
            Properties.Settings.Default.Save();

            balancebox.Text = Properties.Settings.Default.Currency + balance;

            Holdlight.Image = lightoff;
            Nudgelight.Image = lightoff;
            Slot1light.Image = lightoff;
            Slot2light.Image = lightoff;
            Slot3light.Image = lightoff;
            isnudge = false;
            ishold = false;
        }

    }
}
