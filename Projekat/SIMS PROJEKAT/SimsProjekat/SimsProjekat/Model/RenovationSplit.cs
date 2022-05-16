using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class RenovationSplit
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public String NewRoomName1 { get; set; }

        public String NewRoomName2 { get; set; }

        public RoomType NewRoomType1 { get; set; }

        public RoomType NewRoomType2 { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public String Description { get; set; }

        public RenovationSplit(int Id, int RoomId, String NewRoomName1, String NewRoomName2, RoomType NewRoomType1, RoomType NewRoomType2, DateTime Start, DateTime Finish,  String Description)
        {
            this.Id = Id;
            this.RoomId = RoomId;
            this.NewRoomName1 = NewRoomName1;
            this.NewRoomName2 = NewRoomName2; 
            this.NewRoomType1 = NewRoomType1;   
            this.NewRoomType2 = NewRoomType2;
            this.Start = Start;
            this.Finish = Finish;
            this.Description = Description;
        }
        public RenovationSplit(int Id, int RoomId, String NewRoomName1, String NewRoomName2, int newRoomType1, int newRoomType2, DateTime Start, DateTime Finish, String Description)
        {
            this.Id = Id;
            this.RoomId = RoomId;
            this.NewRoomName1 = NewRoomName1;
            this.NewRoomName2 = NewRoomName2;
            NewRoomType1 = (RoomType)newRoomType1;
            NewRoomType2 = (RoomType)newRoomType2;
            this.Start = Start;
            this.Finish = Finish;
            this.Description = Description;
        }

    }
}

