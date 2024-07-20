using CakBum.UserControls;
using System;
using System.Numerics;
using System.Text;
using System.Transactions;

namespace CakBum
{
    public partial class Form1 : Form
    {
        bool _turn = false;
        int countPlayer1 = 4;
        int countPlayer2 =4;
        int tag = 0;
        bool copy = false;
        string pnlCopy = "";
        bool Delete = false;
        int p1 = 0;
        int p2 = 0;

        LisiObj withPic = new LisiObj(); 

        List<UserControl> users = new List<UserControl>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PicClick(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void pictureBox2_DragLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void pictureBox1_DragOver(object sender, DragEventArgs e)
        {

        }

        private void TurnGame(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            Color color = Color.White;
            int t = 0;


            if (countPlayer2 >= 1 && countPlayer1 >= 1)
            {
                if (_turn == false)
                {
                    t = 1;
                    color = Color.Red;
                    _turn = true;
                    countPlayer1--;
                    
                    Countp1.Text = $"{++p1}";
                }
                else
                {
                    t = 2;
                    _turn = false;
                    color = Color.Black;
                    countPlayer2--;
                    Countp2.Text = $"{++p2}";
                }
            }
            else
            {
                if(Delete == false)
                {
                    if (_turn == false)
                    {
                        _turn = true;
                    }
                    else
                    {
                        _turn = false;
                    }
                }
                
            }



            if (copy && Delete == false)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    var obj = users[i] as PictureOfGame;
                    t = (int)obj.Tag;
                    pnlCopy = obj.Parent.ToString();
                }
                
                panel.Tag = t;
                dragPanel(panel, users[0]);
                users.Clear();
                copy = false;
            }
            else
            {
                

                var obj = new PictureOfGame()
                {
                    Player = t,
                    Tag = t,
                    BckColor = color,
                    Parent = panel.Name
                };

                if (countPlayer2 != 0 && countPlayer1 != 0)
                {
                  
                    panel.Tag = t;
                    AddUserContorls(panel, obj);
                    withPic.ListaObj(t,obj);
                }
                obj.MouseClick += (ss, ee) =>
                {

                    var item = (PictureOfGame)ss;
                    if (countPlayer1 <= 1 && countPlayer2 <= 1 && Delete == false)
                    {
                        users.Add(item);
                        copy = true;
                        pnlCopy = item.Parent.ToString();
                    }
                    if (Delete)
                    {
                        int player = item.Player;
                        if (_turn == false)
                        {

                            if (player == 1)
                            {
                                this.Controls[obj.Parent.ToString()].Controls.Remove(item);
                                Delete = false;
                                withPic.Remove(t, item);
                                CheckCount(player);
                            }
                            //Panel panel1 =(Panel) this.Controls[obj.Parent.ToString()];

                            //var itm = panel1.Controls[obj.Name] as PictureOfGame;
                            //itm.Player = 2;
                        }
                        else
                        {
                            if (player == 2)
                            {
                                this.Controls[obj.Parent.ToString()].Controls.Remove(item);
                                Delete = false;
                                withPic.Remove(t, item);
                                CheckCount(player);

                            }
                        }
                    }
                };
            }
        }

        private void CheckCount(int id)
        {
            int count = 0;
            if (id == 1)
                Countp1.Text = $"{withPic.GetListCount(id)}";
            else
                Countp2.Text = $"{withPic.GetListCount(id)}";
        }

        private void dragPanel(Panel panel,UserControl user)
        {
            var obj = (PictureOfGame)user;
            switch (pnlCopy)
            {
                case "pnl1":
                    if (panel.Name == "pnl2" || panel.Name == "pnl10")
                    {
                      
                        if (pnl2.Controls.Count == 0 && panel.Name == "pnl2")
                        {
                            obj.Parent = panel.Name;
                            panel.Controls.Add(obj);
                        }
                        else if (pnl10.Controls.Count == 0 && panel.Name == "pnl10")
                        {
                            obj.Parent = panel.Name;
                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl2":
                    if (panel.Name == "pnl1" || panel.Name == "pnl3" || panel.Name == "pnl5")
                    {
                        if (pnl1.Controls.Count == 0 && panel.Name == "pnl1")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);

                        }
                        else if (pnl3.Controls.Count == 0 && panel.Name == "pnl3")
                        {

                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);

                        }
                        else if (pnl5.Controls.Count == 0 && panel.Name == "pnl5")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);

                        }
                    }
                    break;
                case "pnl3":
                    if (panel.Name == "pnl2" || panel.Name == "pnl15")
                    {
                        if (pnl2.Controls.Count == 0 && panel.Name == "pnl2")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl15.Controls.Count == 0 && panel.Name == "pnl15")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl4":
                    if (panel.Name == "pnl5" || panel.Name == "pnl11")
                    {
                        if (pnl5.Controls.Count == 0 && panel.Name == "pnl5")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl11.Controls.Count == 0 && panel.Name == "pnl11")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl5":
                    if (panel.Name == "pnl2" || panel.Name == "pnl4" || panel.Name == "pnl6" || panel.Name == "pnl8")
                    {
                        if (pnl2.Controls.Count == 0 && panel.Name == "pnl2")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl4.Controls.Count == 0 && panel.Name == "pnl4")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl6.Controls.Count == 0 && panel.Name == "pnl6")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl8.Controls.Count == 0 && panel.Name == "pnl8")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl6":
                    if ( panel.Name == "pnl5" || panel.Name == "pnl14")
                    {
                        if (pnl5.Controls.Count == 0 && panel.Name == "pnl5")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl14.Controls.Count == 0 && panel.Name == "pnl14")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl7":
                    if (panel.Name == "pnl8" || panel.Name == "pnl12")
                    {
                        if (pnl8.Controls.Count == 0 && panel.Name == "pnl8")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl12.Controls.Count == 0 && panel.Name == "pnl12")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl8":
                    if (panel.Name == "pnl7" || panel.Name == "pnl5" || panel.Name == "pnl9")
                    {
                        if (pnl5.Controls.Count == 0 && panel.Name == "pnl5")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl7.Controls.Count == 0 && panel.Name == "pnl7")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl9.Controls.Count == 0 && panel.Name == "pnl9")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl9":
                    if (panel.Name == "pnl8" || panel.Name == "pnl13")
                    {
                        if (pnl8.Controls.Count == 0 && panel.Name == "pnl8")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl13.Controls.Count == 0 && panel.Name == "pnl13")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                       
                    }
                    break;
                case "pnl10":
                    if (panel.Name == "pnl1" || panel.Name == "pnl11" || panel.Name == "pnl22")
                    {
                        if (pnl1.Controls.Count == 0 && panel.Name == "pnl1")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                            Check(panel, user);

                        }
                        else if (pnl11.Controls.Count == 0 && panel.Name == "pnl11")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl22.Controls.Count == 0 && panel.Name == "pnl22")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl11":
                    if (panel.Name == "pnl4" || panel.Name == "pnl12" || panel.Name == "pnl10" || panel.Name == "pnl19")
                    {
                        if (pnl4.Controls.Count == 0 && panel.Name == "pnl4")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl10.Controls.Count == 0 && panel.Name == "pnl10")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl12.Controls.Count == 0 && panel.Name == "pnl12")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl19.Controls.Count == 0 && panel.Name == "pnl19")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;

                case "pnl12":
                    if (panel.Name == "pnl11" || panel.Name == "pnl7" || panel.Name == "pnl16")
                    {
                        if (pnl11.Controls.Count == 0 && panel.Name == "pnl11")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl7.Controls.Count == 0 && panel.Name == "pnl7")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl16.Controls.Count == 0 && panel.Name == "pnl16")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl13":
                    if (panel.Name == "pnl9" || panel.Name == "pnl14" || panel.Name == "pnl18")
                    {
                        if (pnl9.Controls.Count == 0 && panel.Name == "pnl9")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl14.Controls.Count == 0 && panel.Name == "pnl14")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl18.Controls.Count == 0 && panel.Name == "pnl18")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl14":
                    if (panel.Name == "pnl6" || panel.Name == "pnl13" || panel.Name == "pnl15" || panel.Name == "pnl21")
                    {
                        if (pnl6.Controls.Count == 0 && panel.Name == "pnl6")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl13.Controls.Count == 0 && panel.Name == "pnl13")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl15.Controls.Count == 0 && panel.Name == "pnl15")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl21.Controls.Count == 0 && panel.Name == "pnl21")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl15":
                    if (panel.Name == "pnl3" || panel.Name == "pnl14" || panel.Name == "pnl24" )
                    {
                        if (pnl3.Controls.Count == 0 && panel.Name == "pnl3")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl14.Controls.Count == 0 && panel.Name == "pnl14")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl24.Controls.Count == 0 && panel.Name == "pnl24")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                       
                    }
                    break;
                case "pnl16":
                    if (panel.Name == "pnl12" || panel.Name == "pnl17" )
                    {
                        if (pnl12.Controls.Count == 0 && panel.Name == "pnl12")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl17.Controls.Count == 0 && panel.Name == "pnl17")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl17":
                    if (panel.Name == "pnl16" || panel.Name == "pnl18" || panel.Name == "pnl20")
                    {
                        if (pnl16.Controls.Count == 0 && panel.Name == "pnl16")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl18.Controls.Count == 0 && panel.Name == "pnl18")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl20.Controls.Count == 0 && panel.Name == "pnl20")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl18":
                    if (panel.Name == "pnl17" || panel.Name == "pnl13")
                    {
                        if (pnl13.Controls.Count == 0 && panel.Name == "pnl13")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl17.Controls.Count == 0 && panel.Name == "pnl17")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl19":
                    if (panel.Name == "pnl11" || panel.Name == "pnl20")
                    {
                        if (pnl11.Controls.Count == 0 && panel.Name == "pnl11")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl20.Controls.Count == 0 && panel.Name == "pnl20")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl20":
                    if (panel.Name == "pnl17" || panel.Name == "pnl19" || panel.Name == "pnl21" || panel.Name == "pnl23")
                    {
                        if (pnl17.Controls.Count == 0 && panel.Name == "pnl17")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl19.Controls.Count == 0 && panel.Name == "pnl19")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl21.Controls.Count == 0 && panel.Name == "pnl21")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl23.Controls.Count == 0 && panel.Name == "pnl23")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl21":
                    if (panel.Name == "pnl14" || panel.Name == "pnl20")
                    {
                        if (pnl14.Controls.Count == 0 && panel.Name == "pnl14")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl20.Controls.Count == 0 && panel.Name == "pnl20")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl22":
                    if (panel.Name == "pnl10" || panel.Name == "pnl23")
                    {
                        if (pnl10.Controls.Count == 0 && panel.Name == "pnl10")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl23.Controls.Count == 0 && panel.Name == "pnl23")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl23":
                    if (panel.Name == "pnl22" || panel.Name == "pnl20" || panel.Name == "pnl24")
                    {
                        if (pnl20.Controls.Count == 0 && panel.Name == "pnl20")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl22.Controls.Count == 0 && panel.Name == "pnl22")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl24.Controls.Count == 0 && panel.Name == "pnl24")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl24":
                    if (panel.Name == "pnl23" || panel.Name == "pnl15")
                    {
                        if (pnl15.Controls.Count == 0 && panel.Name == "pnl15")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl23.Controls.Count == 0 && panel.Name == "pnl23")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        
                    }
                    break;
                default:
                    break;
            }
        }
        void Check(Panel panel, UserControl user)
        {

            var obj = (PictureOfGame)user;
            int player = tagUsr(user);
            switch (panel.Name)
            {
                case "pnl1":
                    if (player == 1)
                    {
                        if ((pnl2.Controls.Count > 0 && (int)pnl2.Tag == 1) && (pnl3.Controls.Count > 0 && (int)pnl3.Tag == 1))
                        {
                            Delete = true;
                        }
                    }
                    else
                    {
                        if ((pnl2.Controls.Count > 0 && (int)pnl2.Tag == 2) && (pnl3.Controls.Count > 0 && (int)pnl3.Tag == 2))
                        {
                            Delete = true;
                        }
                    }
                    break;
                case "pnl2":
                    if (panel.Name == "pnl1" || panel.Name == "pnl3" || panel.Name == "pnl5")
                    {
                        if (pnl1.Controls.Count == 0 && panel.Name == "pnl1")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);

                        }
                        else if (pnl3.Controls.Count == 0 && panel.Name == "pnl3")
                        {

                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);

                        }
                        else if (pnl5.Controls.Count == 0 && panel.Name == "pnl5")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);

                        }
                    }
                    break;
                case "pnl3":
                    if (panel.Name == "pnl2" || panel.Name == "pnl15")
                    {
                        if (pnl2.Controls.Count == 0 && panel.Name == "pnl2")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl15.Controls.Count == 0 && panel.Name == "pnl15")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl4":
                    if (panel.Name == "pnl5" || panel.Name == "pnl11")
                    {
                        if (pnl5.Controls.Count == 0 && panel.Name == "pnl5")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl11.Controls.Count == 0 && panel.Name == "pnl11")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl5":
                    if (panel.Name == "pnl2" || panel.Name == "pnl4" || panel.Name == "pnl6" || panel.Name == "pnl8")
                    {
                        if (pnl2.Controls.Count == 0 && panel.Name == "pnl2")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl4.Controls.Count == 0 && panel.Name == "pnl4")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl6.Controls.Count == 0 && panel.Name == "pnl6")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl8.Controls.Count == 0 && panel.Name == "pnl8")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl6":
                    if (panel.Name == "pnl5" || panel.Name == "pnl14")
                    {
                        if (pnl5.Controls.Count == 0 && panel.Name == "pnl5")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl14.Controls.Count == 0 && panel.Name == "pnl14")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl7":
                    if (panel.Name == "pnl8" || panel.Name == "pnl12")
                    {
                        if (pnl8.Controls.Count == 0 && panel.Name == "pnl8")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl12.Controls.Count == 0 && panel.Name == "pnl12")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl8":
                    if (panel.Name == "pnl7" || panel.Name == "pnl5" || panel.Name == "pnl9")
                    {
                        if (pnl5.Controls.Count == 0 && panel.Name == "pnl5")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl7.Controls.Count == 0 && panel.Name == "pnl7")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl9.Controls.Count == 0 && panel.Name == "pnl9")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl9":
                    if (panel.Name == "pnl8" || panel.Name == "pnl13")
                    {
                        if (pnl8.Controls.Count == 0 && panel.Name == "pnl8")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl13.Controls.Count == 0 && panel.Name == "pnl13")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl10":
                    if (panel.Name == "pnl1" || panel.Name == "pnl11" || panel.Name == "pnl22")
                    {
                        if (pnl1.Controls.Count == 0 && panel.Name == "pnl1")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                            Check(panel, user);

                        }
                        else if (pnl11.Controls.Count == 0 && panel.Name == "pnl11")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl22.Controls.Count == 0 && panel.Name == "pnl22")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl11":
                    if (panel.Name == "pnl4" || panel.Name == "pnl12" || panel.Name == "pnl10" || panel.Name == "pnl19")
                    {
                        if (pnl4.Controls.Count == 0 && panel.Name == "pnl4")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl10.Controls.Count == 0 && panel.Name == "pnl10")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl12.Controls.Count == 0 && panel.Name == "pnl12")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl19.Controls.Count == 0 && panel.Name == "pnl19")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;

                case "pnl12":
                    if (panel.Name == "pnl11" || panel.Name == "pnl7" || panel.Name == "pnl16")
                    {
                        if (pnl11.Controls.Count == 0 && panel.Name == "pnl11")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl7.Controls.Count == 0 && panel.Name == "pnl7")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl16.Controls.Count == 0 && panel.Name == "pnl16")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl13":
                    if (panel.Name == "pnl9" || panel.Name == "pnl14" || panel.Name == "pnl18")
                    {
                        if (pnl9.Controls.Count == 0 && panel.Name == "pnl9")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl14.Controls.Count == 0 && panel.Name == "pnl14")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl18.Controls.Count == 0 && panel.Name == "pnl18")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl14":
                    if (panel.Name == "pnl6" || panel.Name == "pnl13" || panel.Name == "pnl15" || panel.Name == "pnl21")
                    {
                        if (pnl6.Controls.Count == 0 && panel.Name == "pnl6")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl13.Controls.Count == 0 && panel.Name == "pnl13")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl15.Controls.Count == 0 && panel.Name == "pnl15")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl21.Controls.Count == 0 && panel.Name == "pnl21")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl15":
                    if (panel.Name == "pnl3" || panel.Name == "pnl14" || panel.Name == "pnl24")
                    {
                        if (pnl3.Controls.Count == 0 && panel.Name == "pnl3")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl14.Controls.Count == 0 && panel.Name == "pnl14")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl24.Controls.Count == 0 && panel.Name == "pnl24")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                case "pnl16":
                    if (panel.Name == "pnl12" || panel.Name == "pnl17")
                    {
                        if (pnl12.Controls.Count == 0 && panel.Name == "pnl12")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl17.Controls.Count == 0 && panel.Name == "pnl17")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl17":
                    if (panel.Name == "pnl16" || panel.Name == "pnl18" || panel.Name == "pnl20")
                    {
                        if (pnl16.Controls.Count == 0 && panel.Name == "pnl16")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl18.Controls.Count == 0 && panel.Name == "pnl18")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl20.Controls.Count == 0 && panel.Name == "pnl20")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl18":
                    if (panel.Name == "pnl17" || panel.Name == "pnl13")
                    {
                        if (pnl13.Controls.Count == 0 && panel.Name == "pnl13")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl17.Controls.Count == 0 && panel.Name == "pnl17")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl19":
                    if (panel.Name == "pnl11" || panel.Name == "pnl20")
                    {
                        if (pnl11.Controls.Count == 0 && panel.Name == "pnl11")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl20.Controls.Count == 0 && panel.Name == "pnl20")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl20":
                    if (panel.Name == "pnl17" || panel.Name == "pnl19" || panel.Name == "pnl21" || panel.Name == "pnl23")
                    {
                        if (pnl17.Controls.Count == 0 && panel.Name == "pnl17")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl19.Controls.Count == 0 && panel.Name == "pnl19")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl21.Controls.Count == 0 && panel.Name == "pnl21")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl23.Controls.Count == 0 && panel.Name == "pnl23")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl21":
                    if (panel.Name == "pnl14" || panel.Name == "pnl20")
                    {
                        if (pnl14.Controls.Count == 0 && panel.Name == "pnl14")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl20.Controls.Count == 0 && panel.Name == "pnl20")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl22":
                    if (panel.Name == "pnl10" || panel.Name == "pnl23")
                    {
                        if (pnl10.Controls.Count == 0 && panel.Name == "pnl10")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl23.Controls.Count == 0 && panel.Name == "pnl23")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl23":
                    if (panel.Name == "pnl22" || panel.Name == "pnl20" || panel.Name == "pnl24")
                    {
                        if (pnl20.Controls.Count == 0 && panel.Name == "pnl20")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl22.Controls.Count == 0 && panel.Name == "pnl22")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl24.Controls.Count == 0 && panel.Name == "pnl24")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                    }
                    break;
                case "pnl24":
                    if (panel.Name == "pnl23" || panel.Name == "pnl15")
                    {
                        if (pnl15.Controls.Count == 0 && panel.Name == "pnl15")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }
                        else if (pnl23.Controls.Count == 0 && panel.Name == "pnl23")
                        {
                            obj.Parent = panel.Name;

                            panel.Controls.Add(obj);
                        }

                    }
                    break;
                default:
                    break;
            }
        }
        int tagUsr(UserControl uc)
        {
            var obj = (PictureOfGame)uc;
            return obj.Player;
        }
        void AddUserContorls(Panel pnl, UserControl uc)
        {
            uc.Dock= DockStyle.Fill;
            pnl.Controls.Add(uc);
        }

        private void InGame_Tick(object sender, EventArgs e)
        {
        }
    }
}