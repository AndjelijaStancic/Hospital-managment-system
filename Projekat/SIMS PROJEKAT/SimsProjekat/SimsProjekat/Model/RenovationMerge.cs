using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    public class RenovationMerge
    {
        public int Id { get; set; }

        public int RoomId1 { get; set; }

        public int RoomId2 { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public String NewRoomName { get; set; }

        public RoomType NewRoomType { get; set; }

        public String Description { get; set; }

        public RenovationMerge(int Id, int RoomId1, int RoomId2, DateTime Start, DateTime Finish, String NewRoomName, RoomType NewRoomType, String Description)
        {
            this.Id = Id;
            this.RoomId1 = RoomId1;
            this.RoomId2 = RoomId2;
            this.Start = Start;
            this.Finish = Finish;
            this.NewRoomName = NewRoomName;
            this.NewRoomType = NewRoomType;
            this.Description = Description;
        }
        public RenovationMerge(int Id, int RoomId1, int RoomId2, DateTime Start, DateTime Finish, String NewRoomName, int newRoomType, String Description)
        {
            this.Id = Id;
            this.RoomId1 = RoomId1;
            this.RoomId2 = RoomId2;
            this.Start = Start;
            this.Finish = Finish;
            this.NewRoomName = NewRoomName;
            NewRoomType = (RoomType)newRoomType;
            this.Description = Description;
        }

    }
}
