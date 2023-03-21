//using Model;
//using Service.Entities;
//using Service.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Service.Class
//{
//    public class ShowTicket:IShowTicket
//    {
//        HelpDeskDBEntities db1 = new HelpDeskDBEntities();
//        public List<UserTicket> GetTicketByUserID(int UserId)
//        {
//            UserTicket userticket = new UserTicket();
//            var result = db1.TicketTables.Where(m=>m.Id==UserId).ToList();
            
            
//            return List<result>;
//        }

//    }
//}
