//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB55
{
    using System;
    using System.Collections.Generic;
    
    public partial class PredictedTreatment
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public int DiseaseId { get; set; }
    
        public virtual Disease Disease { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
