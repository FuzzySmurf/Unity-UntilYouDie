======================================================
 _____           _                  
/  __ \         | |                 
| /  \/_   _ ___| |_ ___  _ __ ___  
| |   | | | / __| __/ _ \| '_ ` _ \ 
| \__/\ |_| \__ \ || (_) | | | | | |
 \____/\__,_|___/\__\___/|_| |_| |_|

 _____ _ _     _                    
/  ___| (_)   | |                   
\ `--.| |_  __| | ___ _ __          
 `--. \ | |/ _` |/ _ \ '__|         
/\__/ / | | (_| |  __/ |            
\____/|_|_|\__,_|\___|_|            

======================================================
======================================================

 __   __     ___  ___ 
|__) |__) | |__  |__  
|__) |  \ | |___ |    


	The Custom Sliders use the Unity-GUI extension(s). Implying
that they can only be used within Unity (currently v5.6.0), and 
within the Fuzzy Unity Library files.
	It also uses the ChargeSlider.cs which is a custom script for 
mimicking the UnitySlider scripts that we would need in code, and 
allows us to freely manipulate it as we need. For instance, creating
a normalized attribute.
	

======================================================
======================================================

         __        ___        ___      ___         __  
|  |\/| |__) |    |__   |\/| |__  |\ |  |  | |\ | / _` 
|  |  | |    |___ |___  |  | |___ | \|  |  | | \| \__> 

04/30/2017

	To use the ImplementSlider.cs, simply inherit it, and will allow
for positive and negative adjustments, and regeneration if any.
However, the actual slider settings are done within the Unity Slider.
What this means is that if you wanted to SET the STARTING max value of the 
slider, or the current value of the slider, this is still done within
Unity's inspector, not within the code.
