using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    public interface IDragAndDropControl
    {
        //Methods
        void CheckCanMove();



        //Getters & Setters
        bool CanMoveLeft { get; set; }
        bool CanMoveRight { get; set; }
        bool CanMoveUp { get; set; }
        bool CanMoveDown { get; set; }
    }
}
