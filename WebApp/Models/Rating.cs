using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp.Models
{
    public class Rating
    {
        public Rating() { }
        public Rating (int Id_Client, int Id_Antrenori, int Score)
        {
            this.Id_Client = Id_Client;
            this.Id_Antrenor = Id_Antrenori;
            this.Score = Score;
        }
        public int Id { get; set; }
        public int Id_Client { get; set; }
        public virtual Client Client { get; set; }
        public int Id_Antrenor { get; set; }
        public virtual Antrenor Antrenor { get; set; }
        public int Score { get; set; }

    }
}