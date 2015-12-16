using Postgaarden.Model.Equipments;
using Postgaarden.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgaarden.Model.Rooms;

namespace Postgaarden.Crud.Equipments
{
    /*
        Developed by Chris Wohlert
    */
    public abstract class EquipmentCrud : Crud<Equipment, int>
    {
        public abstract IEnumerable<Equipment> Read(Room room);
        public abstract void Update(Equipment equipment, Room room);
    }
}
