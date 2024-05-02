INCLUDE globals.ink

Hello there!
-> main

=== main ===
Hay salamat! Kaunti nalang ang mga gawain 
kaya pwede na tayo magpahinga pagkatapos nito.
+ [Ako na po sa mga natitirang gawain ‘nay para makapagpahinga na po kayo.]
    ~ dialogueEnd = true
    -> chosen
+ [Mabuti naman! Kanina pa tayo naglilinis eh.]
    ~ dialogueEnd = false
    -> chosen
    
=== chosen ===
Batiin mo yung mga kapitbahay natin para makilala mo ng sila 

-> END