using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Tracker.Entities.Tracker
{
    public class RealCases
    {
        public Guid ID { get; set; }
        public States State { get; set; }
        public int Cases { get; set; }
        public int Recorvered { get; set; }
        public int Sick { get; set; }
        public int Death { get; set; }
        public int Tested { get; set; }

    }

    public enum States
    {
        Abuja,
                           Abia,
                            Adamawa,
                             AkwaIbom,
                            Anambra,
                           Bauchi,
 
                             Bayelsa,
  
                            Benue,
   
                             Borno,
    
                            CrossRiver,
                            Delta,
                             Ebonyi,
 
                             Edo ,
  
                           Ekiti,
   
                             Enugu,
    
                            Gombe,
     
                            Imo ,
      
                            Jigawa,
       
                           Kaduna,
        
                           Kano,
         
                           Katsina,
          
                           Kebbi,
                           Kogi,
            
                           Kwara,
             
                           Lagos,
              
                                    Nassarawa ,
               
                                    Niger ,
                                          
                                    Ogun ,
                                          
                                    Ondo,
                                          
                                    Osun ,
                                          
                                    Oyo ,
                                          
                                   Plateau,
                                          
                                   Rivers ,
                                          
                                   Sokoto ,
                                          
                                   Taraba,
                        
                                   Yobe,
                         
                                   Zamfara
    }
}
