INCLUDE globals.ink

{ playerProgress >= 1: -> NearbyHouse}
{ NearbyHouseEnd == true: -> EndDialogue}


=== NearbyHouse ===
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
Luad sees their neighbor hanging around outside their house, who was the one who helped them carry in their things when the movers came.


#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
Hey Luad! How’s moving in coming along? Do you guys need help in carrying more heavy stuff?

+[We're not done yet but we can handle it, thank you for helping us earlier!]
    ~goodChoicesCounter += 1
    ->goodChoice0("choiceItem0")
  
+[No, we’re good.]
    ~goodChoicesCounter += 1
    ->NextDialogue1
    
+[Stop bothering us.]
    ~badChoicesCounter += 1
    ->badChoiceNoItem
    
=== goodChoice0(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>UTANG NA LOOB!</b>
->NextDialogue1

=== badChoiceNoItem ====
#speaker:KapitBahay  #portrait:KapitBahay_Angry_Idle #layout:left #voiceover:default
Oh, okay then.
    ->NextDialogue2

=== NextDialogue1 ===
#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
Oh is that so? Well if you guys need any help or if you need to fix something up, just call me. 

#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
I'm a mechanic that helps around here in the neighborhood.

+[Same goes to you, if you need help on anything, don't be shy to ask us for help.]
    ~goodChoicesCounter += 1
    ->goodChoice1("choiceItem1")
  
+[Okay thanks for the offer but we can handle it.]
    ~goodChoicesCounter += 1
    ->NextDialogue2
    
=== goodChoice1(choiceItem) ===
You Have Obtained <color="blue"><b>PAKIKISAMA!</b>
    ->NextDialogue2

=== NextDialogue2 ===
#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
Are you sure? It might be difficult for you since it's just the two of you taking care of things.

#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
Don't be shy to ask us for help here, this is how it is here in the barangay, we work together.


+[Thank you so much for the offer, but I can handle finishing the housework. I'm used to doing this so there's nothing to worry about.]
    ~goodChoicesCounter += 1
    ->goodChoice2("choiceItem2")
  
+[Ohh so that's how it is here. We're also ready to help people here in the barangay.]
    ~goodChoicesCounter += 1
    ->goodChoice3("choiceItem3")

    
=== goodChoice2(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>AMOR PROPIO!</b>
    ->NextDialogue3
    
=== goodChoice3(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>BAYANIHAN!</b>
    ->NextDialogue3
    
=== NextDialogue3 ===
#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
Ah, by the way, the sports fest is coming up here in the barangay. Why don't you try joining? 

#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
You can already register as early as now even though the registration ends by the end of the month.

#speaker:KapitBahay  #portrait:KapitBahay_Idle #layout:left #voiceover:default
You want to join?

+[Okay I'll try joining. But I'm not that skilled to play. I hope I'll make the cut.]
    ~goodChoicesCounter += 1
    ->goodChoice4("choiceItem4")
  
+[Okay but I'm not really fond of playing those games. Whatever goes I guess!]
    ~goodChoicesCounter += 1
    ->goodChoice5("choiceItem5")
    
+[Is that so? Okay, I'll just check it out next time. The end of registration is still far off anyway.]
    ~badChoicesCounter += 1
    ->badChoice("choiceItem6")

=== goodChoice4(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>HIYA!</b>
    ->NextDialogue4
    
=== goodChoice5(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>BAHALA NA!</b>
    ->NextDialogue4

=== badChoice(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="red"><b>MANANA!</b>
    ->NextDialogue4
    
=== NextDialogue4 ===
#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
Okay just make sure to join! You can do it! It's also easy to get along with people here,

#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
so you won't have any trouble socializing with them. Besides, just have enjoy while playing.

#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
The sports fest here are not to be taken seriously, just for fun. 

#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:left #voiceover:default
Alright, I'll be off then. See you next time!

->EndDialogue   


=== EndDialogue ===
~playerProgress += 1
~NearbyHouseEnd = true
#speaker:KapitBahay  #portrait:KapitBahay_Idle #layout:left #voiceover:default
Go talk to other people to get know the area!
->END