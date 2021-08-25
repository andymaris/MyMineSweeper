using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameDemo
{
    public partial class TileDemo : Form
    {

        bool b_EZ = false;
        bool[] map = new bool[36];
        int FieldSize = 36; //default
        int HashSize = 6;   //default
        int counter = 0;
        bool Won = false;

        Bitmap flg = new Bitmap(@".\..\Assets\flag.jpg");
        Bitmap mne = new Bitmap(@".\..\Assets\mine.jpg");
        //C:\Users\andym\source\Tile Game Demos - dynamic buttons\TileGameDemo\TileGameDemo\bin\
        public TileDemo()
        {
            InitializeComponent();
        }

        private void TileDemo_Load(object sender, EventArgs e)
        {

        }

        private void Easy_Click(object sender, MouseEventArgs e)
        {

            HashSize = 9;
            FieldSize = HashSize * HashSize;
            map = new bool[FieldSize];
            Button b = (Button)sender;

            counter = 0; //re- set to 0 if it's a new game;
            Random flip = new Random();
            //map of where the mines are.  add better random selection later
            for (int i = 0; i < FieldSize; i++)
            {
                map[i] = false;  //set all but a few to false
                /*   //DEBUG THE PATH FINDING ALGORITHM
                int coin = flip.Next(0, 10000);
                if (coin % 13 == 0 || coin % 11 == 0 || coin % 17 == 0)
                {
                    //if (coin % 13 == 0)
                    map[i] = true;
                    counter++;
                }
                else
                    map[i] = false;
                */  //DEBUG THE PATH FINDING ALGORITHM
            }

            map[0] = map[3] = map[7] = map[11] = map[17] = map[36] = true;
            map[46] = map[49] = map[53] = map[55] = map[56] = map[60] = map[61] = map[62] = map[63] = true;
            map[67] = map[68] = map[69] = map[77] = true;

            /*
            //update the mine remaining count
            Label l = Controls.Find("CountDown", true)[0] as Label;
            l.Text = counter.ToString() + "  Remaining";
            */
            update_counter();
            if (b_EZ)
            {
                //reset the game 
                //this means going and getting all the buttons and changing their text.
                //might be easiest if this were an array of buttons.
                Won = false;
                update_counter();

                foreach (Control c in Controls) {
                    if (c is Button && (c.Text != "Easy")) {
                        c.Text = "";
                        c.BackColor = Color.LightGray;
                        //should be an easier way to get to the image, but this works.
                        Button temp = Controls.Find(c.Name, true)[0] as Button;
                        temp.Image = null;
                       
                        
                        }
                    
                    }
                return;
            }

            int button_size = 35;
            int name = 0;
            for (int i = 0; i < HashSize; i++)
                for (int j = 0; j < HashSize; j++)
                {
                    Button btn = new Button();
                    btn.Text = "";
                    btn.Name = (name.ToString());
                    name++;
                    btn.Size = new Size(button_size, button_size);
                    btn.BackColor = Color.LightGray;
                    //btn.Margin = new Padding(0,0,0,0);
                    btn.Location = new Point((j * button_size) + 200, (i * button_size) + 100);
                    btn.MouseDown += new MouseEventHandler(this.Tile_Click);

                    Controls.Add(btn);
                }

            b_EZ = true;
        }


        void Tile_Click(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            int index = int.Parse(b.Name);

            if (Won == true)
                return;

            if (b.Text == "F")
                return;

            if (e.Button.Equals(MouseButtons.Left))
            {

                if (map[index] == false)  // do a call to update  neighbors.
                {
                    int DangerCount = UpdateNeighborhood(index);
                }
                else
                {
                   // b.Text = "!";   //boom- you lose.
                    YouLost();
                }
            }


            if (e.Button.Equals(MouseButtons.Right))
            {
                //if (b.Text == "X")
                if(b.Image == flg)
                {
                    b.Text = "?";   //not sure
                    b.Image = null;
                    counter++;
                }
                else if (b.Text == "?")
                    b.Text = "";    //return to blank
                
                else if (b.Text == "")  //don't allow clicks on numbers
                {
                    b.Image = flg;  //mark as bomb
                    if (counter > 0)
                        counter--;
                }
            }

            if(counter == 0)
            {
                int invisible_counter = 0;
                //check index to see if Xs match bombs.
                for(int i = 0; i<FieldSize; i++)
                {
                    if (map[i])
                    {
                        string check = i.ToString();
                        Button c = Controls.Find(check, true)[0] as Button;
                        if (c.Text != "X" && c.Image != flg)
                            invisible_counter++;
                    }
                    if (invisible_counter == 0)
                        Won = true;

                }

            }  //end counter is zero

            update_counter();




        }// end tile click

        //Update Neighborhood.  Check and update the current tile and neighbors until a bomb  or limit is hit.  
        //
        // todo: will be recursive.
        //IN: the index to check
        //CHANGE the current tile to FREE or The count of neighbors that are bombs
        // Return: count of adjacent mines- but make that go away once it's recursive
        //check left (left, and left up/down)
        //check right (right, and right up/down)
        //check up
        //check down

        int UpdateNeighborhood(int mapindex, bool recurse = false)
        {

            int bombcount = 0;

            string indx = mapindex.ToString();
            foreach (Control c in Controls)
                if (c is Button)
                {
                    Button temp = Controls.Find(c.Name, true)[0] as Button;
                    if (temp.Image != null)
                        return 0;

                    if (c.Name == indx)
                        switch (c.Text)
                        {
                           // case "!":


                            case "F":
                           // case "X":
                            case "?":
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                                return 0;
                                break;
                        }
                }


            //check left, if there is a left

            if (mapindex > 0 && (mapindex % HashSize != 0))
            {
                if (map[mapindex - 1])
                    bombcount++;
                //look left up 
                if (mapindex - 1 - HashSize >= 0)
                    if (map[mapindex - 1 - HashSize])
                        bombcount++;
                //look left down
                if (mapindex - 1 + HashSize < FieldSize)
                    if (map[mapindex - 1 + HashSize])
                        bombcount++;

            }

            //check right, if there is a right
            int r_indx = mapindex + 1;
            if (mapindex < FieldSize && (mapindex % HashSize != (HashSize - 1)))
            {

                if (map[r_indx])
                    bombcount++;

                //look right up 

                if (r_indx - HashSize > 0)  //dont go below zero
                    if (map[r_indx - HashSize])
                        bombcount++;
                //look right down
                if (r_indx + HashSize < FieldSize)
                    if (map[r_indx + HashSize])
                        bombcount++;

            }
            //check above, if there is an above
            if (mapindex - HashSize >= 0)
            {
                if (map[mapindex - HashSize])
                    bombcount++;

            }
            //check below, if there is a below
            if (mapindex + HashSize < FieldSize)
            {
                if (map[mapindex + HashSize])
                    bombcount++;

            }

            foreach (Control c in Controls)
                if (c is Button)
                    if (c.Name == indx)
                    {
                        if (bombcount > 0)
                            c.Text = bombcount.ToString();
                        else  //do this only if recurse is true?????

                            c.Text = "F";  //comment this out to see if the dot is working

                        c.BackColor = Color.LightBlue;
                    }
            //recursively check neighbors to the end.

            //recurse left until you hit a bomb... but don't do it if adjacent to undiscovered bomb
            if (mapindex > 0 && (mapindex % HashSize != 0))
                if ((recurse || bombcount == 0) && (map[mapindex - 1] == false))
                    UpdateNeighborhood(mapindex - 1, true);

            //keep checking right till you hit the end or a bomb;
            if (mapindex < FieldSize && (mapindex % HashSize != (HashSize - 1)))
                if ((recurse || bombcount == 0) && (map[r_indx] == false))
                    UpdateNeighborhood(r_indx, true);


            //keep checking above until you hit top or a bomb
            if (mapindex - HashSize >= 0)
                if ((recurse || bombcount == 0) && (map[mapindex - HashSize] == false))
                    UpdateNeighborhood(mapindex - HashSize, true);

            //keep checking down until you hit bottom or a bomb
            if (mapindex + HashSize < FieldSize)
                if ((recurse || bombcount == 0) && (map[mapindex + HashSize] == false))
                    UpdateNeighborhood(mapindex + HashSize, true);


            return bombcount;
        }


        void YouLost()
        {

            //fixing...inefficient, but need to know the interface better before I can clean it up.
            for (int i = 0; i < FieldSize; i++)
            {
                string indx = i.ToString();
                Button b = Controls.Find(indx, true)[0] as Button;

                if (map[i] == true)
                {
                    //b.Text = "!";
                    b.Image = mne;
                }
                else
                {
                    //b.Text = "-";
                    b.BackColor = Color.LightBlue;
                }

            }


        }//end you lost function

        void update_counter()
        {

            //update the mine remaining count... 
            Label l = Controls.Find("CountDown", true)[0] as Label;
            if (Won)
                l.Text = "You Won!";
            else
                l.Text = counter.ToString() + "  Remaining";
        }
    } //end class
}//end name space


