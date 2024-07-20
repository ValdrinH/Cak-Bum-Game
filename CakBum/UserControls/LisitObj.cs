using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakBum.UserControls
{
    public class LisiObj
    {
        List<PictureOfGame> Player1 = new List<PictureOfGame>();
        List<PictureOfGame> Player2 = new List<PictureOfGame>();
        public void ListaObj(int p,PictureOfGame userControl)
        {
            if (p == 1)
            {
                Player1.Add(userControl);
            }
            else
            {
                Player2.Add(userControl);
            }
        }
        public int GetListCount(int ID)
        {
            if (ID == 1)
                return Player1.Count;
            else
                return Player2.Count;
        }
        public void Remove(int ID, PictureOfGame pic )
        {
            if (ID == 1)
                Player1.Remove(pic);
           
            else
                Player2.Remove(pic);
        }
    }
}
