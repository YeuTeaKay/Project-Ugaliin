INCLUDE globals.ink

{ BarangayHallEnd == true: -> EndDialogue}
{ playerProgress >= 1: -> BarangayHall}


=== BarangayHall ===
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
Luad goes to the Barangay Hall to inform the Barangay Captain that they have arrived in the community. 

#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
He sees the people in there busy setting up banners for the upcoming fiesta. 

#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
Luad approaches the Barangay Captain who seems to have trouble putting up the banners in their office.

+[Here captain! (hands out the banner)]
    ~goodChoicesCounter += 1
    ->goodChoice0("choiceItem0")
+[Hello! Good day captain!]
    ~goodChoicesCounter += 1
    ->NextDialogue0
+[(waits for captain to finish)]
    ~badChoicesCounter += 1
    ->NextDialogue0
    
=== goodChoice0(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>BAYANIHAN!</b>

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Oh thank you! Hold on, I'll just finish this part over here.
    ->NextDialogue1
    
=== NextDialogue0 ===
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Oh! I didn't know someone was waiting. Hold on, I'll just finish this part over here.
    ->NextDialogue1

=== NextDialogue1 ===
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Come, come, sit. I do apologize for the whole office being busy at making the place look beautiful. 
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
We are going to hold a fiesta soon that's why we're preparing for it really well. 

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Ah erm, wait a minute, you don't seem familiar. Who are you?

+[Good day! My name is Luad. We're the ones who just moved in the house at the end of the street. I'm living with my mother.]
    ~goodChoicesCounter += 1
    ->NextDialogue2
+[I am Luad. My mother just sent me to let you know that we have moved in.]
    ~badChoicesCounter += 1
    ->NextDialogue2
    
=== NextDialogue2 ===
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Well by the looks of it, moving it went well. Are your things okay? Nothing broke? 

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
I hope the people we sent were careful. I'm sorry that I can't personally be there. 

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
There's been a lot of things going on here 

+[Good day! My name is Luad. We're the ones who just moved in the house at the end of the street. I'm living with my mother.]
    ~goodChoicesCounter += 1
    ->goodChoice1("choiceItem0")
+[I am Luad. My mother just sent me to let you know that we have moved in.]
    ~badChoicesCounter += 1
    ->badDialogue0

=== goodChoice1(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>BAYANIHAN!</b>

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
You're welcome. That's how we are here in the barangay, we work together.
    ->NextDialogue3
    
=== badDialogue0 ===
Those people are careful. They know what they are doing, that's why they help around here.
    ->NextDialogue3
    
=== NextDialogue3 ===
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
How about you? How is the barangay for you? Are you comfortable? 

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
You know, at your age, you can join the youth that helps our barangay. 

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
It looks like you can and it will be a big help for them.

+[Oh I'm not that good to join in those. I can just help out a bit.)]
    ~goodChoicesCounter += 1
    ->goodChoice2("choiceItem1")
+[Sure! I'm capable in helping for the good of the barangay.]
    ~goodChoicesCounter += 1
    ->goodChoice3("choiceItem2")
+[Sure but, I can't promise that I can help all the time. I have no interest in those things. I might just end up wasting my time.]
    ~badChoicesCounter += 1
    ->badChoice0("choiceItem3")
    
=== goodChoice2(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>HIYA!</b>
    ->NextDialogue4

=== goodChoice3(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>AMOR PROPIO!</b>
    ->NextDialogue4

=== NextDialogue4 ===    
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Don't worry, us your elders are here to help and guide the youth in establishing our community.
    ->NextDialogue5

=== badChoice0(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>NINGAS COGON!</b>

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Helping people is not a waste of time. Remember that they might also be the ones helping you someday.
    ->NextDialogue5

=== NextDialogue5 ===
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Tell your mother that after our work here, we'll visit you to check your status 

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
and if there are other information that you guys may want to know about our place.

+[You're welcome to visit us anytime, so don't be shy in coming over.]
    ~goodChoicesCounter += 1
    ->goodChoice4("choiceItem4")
+[No need. We can just ask around if we need to know something.]
    ~badChoicesCounter += 1
    ->NextDialogue6

=== goodChoice4(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>HOSPITALITY!</b>
    ->NextDialogue6
    
=== NextDialogue6 ===
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Oh really? Okay then, I need to finish setting up the banners here. 

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
Thank you so much for visiting our humble barangay hall. 

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:left #voiceover:default
If you guys need anything at all, we are ready to serve you. Again, thank you so much Luad! See you soon!
    ->EndDialogue
    
=== EndDialogue ===
~playerProgress += 1
~BarangayHallEnd = true
#speaker:Lola Tindera  #portrait:Lola_Idle #layout:left #voiceover:default
Go roam the streets and talk to other people


->END
