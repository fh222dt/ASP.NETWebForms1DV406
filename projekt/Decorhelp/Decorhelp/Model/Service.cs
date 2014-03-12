using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Decorhelp.Model.DAL;
using System.ComponentModel.DataAnnotations;

namespace Decorhelp.Model
{
    public class Service
    {
        //fält
        private DecorareaDAL _decorareaDAL;
        private DecoritemDAL _decoritemDAL;
        private PlacedDAL _placedDAL;

        //Egenskaper
        private DecorareaDAL DecorareaDAL
        {
            get { return _decorareaDAL ?? (_decorareaDAL = new DecorareaDAL()); }
        }

        private DecoritemDAL DecoritemDAL
        {
            get { return _decoritemDAL ?? (_decoritemDAL = new DecoritemDAL()); }
        }

        private PlacedDAL PlacedDAL
        {
            get { return _placedDAL ?? (_placedDAL = new PlacedDAL()); }
        }

        //create/update metoder
        public void SaveDecorArea(Decorarea decorarea)
        {
            ICollection<ValidationResult> validationResults;
            if (!decorarea.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            //create
            if (decorarea.decorAreaID == 0) // Ny post om decorareaID är 0
            {
                DecorareaDAL.InsertDecorArea(decorarea);
            }
            //update
            else
            {
                DecorareaDAL.UpdateDecorArea(decorarea);
            }
        }

        public void SaveDecorItem(Decoritem decoritem)
        {
            ICollection<ValidationResult> validationResults;
            if (!decoritem.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            //create
            if (decoritem.decorItemID == 0) // Ny post om decorareaID är 0
            {
                DecoritemDAL.InsertDecorItem(decoritem);
            }
            //update
            else
            {
                DecoritemDAL.UpdateDecorItem(decoritem);
            }
        }

        //read metoder
        public Decorarea GetDecorArea(int decorAreaID)
        {
            return DecorareaDAL.GetDecorAreaById(decorAreaID);
        }

        public Decoritem GetDecorItem(int decorItemID)
        {
            return DecoritemDAL.GetDecorItemById(decorItemID);
        }

        public Placed GetPlaced(int decorItemID)
        {
            return PlacedDAL.GetPlacedById(decorItemID);
        }
        
        public IEnumerable<Decorarea> GetDecorAreas()
        {
            return DecorareaDAL.GetDecorAreas();
        }

        public IEnumerable<Decoritem> GetDecorItems()
        {
            return DecoritemDAL.GetDecorItems();
        }

        public IEnumerable<Placed> GetAllPlaced()
        {
            return PlacedDAL.GetAllPlaced();
        }
        
        //delete metoder
        public void DeleteDecorArea(int decorAreaID)
        {
            DecorareaDAL.DeleteDecorArea(decorAreaID);
        }

        public void DeleteDecorItem(int decorItemID)
        {
            DecoritemDAL.DeleteDecorItem(decorItemID);
        }
    }
}