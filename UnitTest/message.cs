
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public abstract class Message
    {
     public   abstract void execute();
    }

    public class MessageA : Message
    {

  

       

        public override void execute()
        {
            throw new NotImplementedException();
        }
    }

public class MessageB : Message
{



       

        public override void execute()
        {
            throw new NotImplementedException();
        }
    }

public class MessageC : Message
{




        public override void execute()
        {
            throw new NotImplementedException();
        }
    }

public class Programe 
{

    public static void main()
    {
        Message message = new MessageA();
        message.execute();


    }

}
}
