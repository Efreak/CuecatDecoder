using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuecatDecoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        // Handle the KeyDown event to determine the type of character entered into the control. 
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Determine whether the keystroke is a enter 
            if (e.KeyCode == Keys.Enter)
            {
                string stringreferencechars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+-";
                string[] encodedinput1 = this.textBox1.Text.Substring(1,this.textBox1.Text.Length-1).Split('.');
                string[] encodedinput = encodedinput1[encodedinput1.Length-1].Select(c => c.ToString()).ToArray();
                string tempvar = "";

                for (int current = 0; current < encodedinput.Length; current++)
                {
                    int step5 = 0;
                    int step15 = 0;
                    string curchar;
                    try
                    {       //yes, you numskulls, I know this is horrible code. deal with it. I'm following the guide at
                            //http://www.rkgage.net/bobby/cuecat/decode2.htm step by step.
                        curchar = encodedinput[current]; //get the first character
                        int step1 = stringreferencechars.IndexOf(curchar); //get the first character's position
                        int step2 = step1 - 1;
                        int step3 = step2 << 2;
                        current++;
                        curchar = encodedinput[current]; //get the second character
                        int step4 = stringreferencechars.IndexOf(curchar); //get the second character's position
                        step5 = step4 - 1;
                        int step6 = step5 >> 4;
                        int step7 = step3 | step6;
                        int step8 = step7 | 3;
                        int step9 = step8 + 64;
                        int step10 = (step9 > 128 ? step9 - 128 : step2);
                        char step11 = (char) step10;
                        tempvar += step11;
                    }
                    catch { }
                    //step12: end if there's no other character
                    try
                    {
                        int step13 = step5 << 4;
                        current++;
                        curchar = encodedinput[current]; //get the third character
                        int step14 = stringreferencechars.IndexOf(curchar); //get the third character's position
                        step15 = step14 - 1;
                        int step16 = step15 << 2;
                        int step17 = step13 | step16;
                        int step18 = step17 ^ 3;
                        int step19 = step18 + 64;
                        int step20 = (step19 > 128 ? step19 - 128 : step19);
                        char step21 = (char)step20;
                        tempvar += step21;
                    } catch {}
                    //step 22: end if there's no other character.
                    try
                    {
                        int step23 = step15 << 6;
                        current++;
                        curchar = encodedinput[current]; //get the fourth character
                        int step24 = stringreferencechars.IndexOf(curchar); //get the fourth character's position
                        int step25 = step24 - 1;
                        int step26 = step23 | step25;
                        int step27 = step26 ^ 3;
                        int step28 = step27 + 64;
                        char step29 = (char)step28;
                        tempvar += step29;
                    }
                    catch { }
                }
                this.textBox1.Text = tempvar;
            }
        }
    }
}
