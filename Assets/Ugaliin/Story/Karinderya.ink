INCLUDE globals.ink

{ playerProgress == 0: -> TalkToMother}
{ karinderyaEnd == true: -> EndDialogue}
{ playerProgress >= 1: -> Karinderya}


=== TalkToMother ===
#speaker:Lola Tindera  #portrait:Lola_Talking #background:Karinderya #layout:Default #voiceover:default
Very busy right now, talk to me later kid.
->DONE

=== Karinderya ===
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
Luad passes by the Karinderia where they can buy food if they have none at home, or where they can buy some snacks. 
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
The place is popular in their neighborhood but the vendor looks troubled right now.

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT0
Buy now! The dishes here  are delicious and cheap!

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT1
 Oh, you kid? Wait, I don't recognize you, are you new here? 

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT2
Ah! You're the new people who recently just moved in right? 

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT3
Come here and eat, everything is freshly cooked so it's still warm.

+[Mano po lola! Okay! (checks out the dishes)]
    ~goodChoicesCounter += 1
    ->goodChoice0("choiceItem10")
+[Hello! The dishes here look so delicious!]
    ~goodChoicesCounter += 1
    ->NextDialogue0
+[I'm not fond of eating in places like this.]
    ~badChoicesCounter += 1
    ->NextAngryDialogue0
    
=== goodChoice0(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:RespectForTheElderly #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>RESPECT FOR THE ELDERLY!</b>
    ->NextDialogue0
    
=== NextDialogue0 ===
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT4
Oh you're very kind and energetic! Just choose what you want, don't be shy!
    ->NextDialogue1
    
=== NextAngryDialogue0 ===
#speaker:Lola Tindera  #portrait:Lola_Angry_Talking #layout:Default #voiceover:LT5
My dishes are delicious and there is nothing wrong with places like this.
    ->NextDialogue1 

=== NextDialogue1 ===
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT6
My karinderya is the tastiest and most famous eatery here in the barangay! 
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:left #voiceover:LT7
However, I have a problem right now. My helper here is on vacation, that's why I'm the only one managing thing around here.
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT8
I also have a lot of deliveries lined up today. I don't know what to do.

+[What can I do to help you lola? I don't have anything to do anyway.]
    ~goodChoicesCounter += 1
    ->goodChoice1("choiceItem9")
    
+[You can do it! Just trust in yourself. You can overcome this hurdle today.]
    ~goodChoicesCounter += 1
    ->goodChoice2("choiceItem1")
    
+[Just close up shop. Today seems exhausting for you.]
    ~badChoicesCounter += 1
    ->NextAngryDialogue1
    
=== goodChoice1(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Pakikisama #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>PAKIKISAMA!</b>
    ->NextDialogue2
    
=== goodChoice2(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:BahalaNa #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>BAHALA NA!</b>
    ->NextDialogue2
    
=== NextDialogue2 ===
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT9
I really hope so kid. I wish what you said will come true.
    ->MiniGame

=== NextAngryDialogue1 ===
#speaker:Lola Tindera  #portrait:Lola_Angry_Talking #layout:Default #voiceover:LT10
That can't be! My beloved karinderya's reputation will be tarnished.
    ->MiniGame

=== NextDialogue3 ===
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT11
I would like to ask help from you kid, if maybe you can deliver these food to the people.

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT12
I'll give you some food later to bring home, for free! Then next time you buy from here, I'll give you a discount.

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT13
What do you think? Sounds good?
 
+[What can I do to help you lola? I don't have anything to do anyway.]
    ~goodChoicesCounter += 1
    ->goodChoice3("choiceItem9")
+[You can do it! Just trust in yourself. You can overcome this hurdle today.]
    ~badChoicesCounter += 1
    ->MiniGame
=== goodChoice3(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Pakikisama #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>PAKIKISAMA!</b>
    ->MiniGame

=== MiniGame ===
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT14
There! Thank you! Thank god you passed by. Here are the people that you'll deliver the food to. 

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT15
You need to be fast so that the food will still be warm when it reaches them.

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT16
Okay, good luck!

~playerPoints = 0
->Question1
=== Question1 ===
#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:Quiz #voiceover:default
Hello luad I would like to order 1 Sinigang!
#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:Quiz #voiceover:default
You got that?
+[1 Sinigang.]
    ->RightAnswer1
+[1 Adobo.]
    ->WrongAnswer1
+[1 Giniling.]
    ->WrongAnswer1
    
=== RightAnswer1 ===
~playerPoints += 1
#speaker:Barangay Captain  #portrait:KapitBahay_Talking #layout:Quiz #voiceover:default
Nice it looks so good anyways goodluck at taking orders Luad!
    ->Question2
=== WrongAnswer1 ===
#speaker:Barangay Captain  #portrait:KapitBahay_Default #layout:Quiz #voiceover:default
You got the wrong order Luad...
    ->Question2
    
=== Question2 ===
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:Quiz #voiceover:default
Hello Luad, I would like to order 1 Adobo and 1 Sinigang

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:Quiz #voiceover:default
You got that?
+[1 Adobo and 1 Giniling]
    ->WrongAnswer2
+[1 Adobo and 1 Sinigang]
    ->RightAnswer2
+[1 Giniling and 1 Sinigang]
    ->WrongAnswer2
    
=== RightAnswer2 ===
~playerPoints += 1
#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:Quiz #voiceover:default
Nice it looks so good anyways goodluck at taking orders Luad!
    ->Question3
=== WrongAnswer2 ===
#speaker:Barangay Captain  #portrait:Barangay_Default #layout:Quiz #voiceover:default
You got the wrong order Luad...
    ->Question3

=== Question3 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Quiz #voiceover:default
Hello Anak, I would like to order 1 Sinigang and 2 Giniling for our dinner.

#speaker:Mother  #portrait:Mother_Talking #layout:Quiz #voiceover:default
You got that nak?

+[1 Adobo and 2 Sinigang]
    ->WrongAnswer3
+[2 Adobo and 1 Sinigang]
    ->WrongAnswer3
+[1 Sinigang and 2 Giniling.]
    ->RightAnswer3

=== RightAnswer3 ===
~playerPoints += 1
#speaker:Mother  #portrait:Mother_Talking #layout:Quiz #voiceover:default
Nice it looks so good anyways goodluck at taking orders Luad!
    ->Question4
=== WrongAnswer3 ===
#speaker:Mother  #portrait:Mother_Default #layout:Quiz #voiceover:default
You got the wrong order Luad...
    ->Question4

=== Question4 ===
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Quiz #voiceover:default
Hello Luad, I would like to order 1 Adobo, 1 Sinigang and 1 Giniling

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Quiz #voiceover:default
You got that?
+[1 Adobo and 1 Giniling]
    ->WrongAnswer4
+[1 Adobo, 1 Sinigang and 1 Giniling]
    ->RightAnswer4
+[1 Sinigang and 1 Giniling]
    ->WrongAnswer4

=== RightAnswer4 ===
~playerPoints += 1
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Quiz #voiceover:default
Nice it looks so good anyways goodluck at taking orders Luad!
    ->Question5
=== WrongAnswer4 ===
#speaker:Tita Grace  #portrait:Tita_Default #layout:Quiz #voiceover:default
You got the wrong order Luad...
    ->Question5

=== Question5 ===
#speaker:Gilbert  #portrait:MCBoy_Talking #layout:Quiz #voiceover:default
I would like to order 1 Adobo, 2 Sinigang and 2 Giniling

You got that?
+[2 Adobo, 2 Sinigang and 1 Giniling]
    ->WrongAnswer5
+[2 Adobo, 1 Sinigang and 2 Giniling]
    ->WrongAnswer5
+[1 Adobo, 2 Sinigang and 2 Giniling]
    ->RightAnswer5

=== RightAnswer5 ===
~playerPoints += 1
#speaker:Gilbert  #portrait:MCGirl_Talking #layout:Quiz #voiceover:default
Nice it looks so good anyways goodluck at taking orders Luad!
    ->CheckScore
=== WrongAnswer5 ===
#speaker:Gilbert  #portrait:MCBoy_Talking #layout:Quiz #voiceover:default
You got the wrong order Luad...
    ->CheckScore
    

=== CheckScore ===
{ playerPoints >= 4: -> YouWin("choiceItem2") }
{ playerPoints <= 3: -> YouLose }

=== YouWin(choiceItem) ===
~playerChoice = choiceItem
~goodChoicesCounter += 1
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
You got most of the orders correctly!

#speaker:Narrator  #portrait:Bayanihan #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>BAYANIHAN!</b>
    ->NextDialogue4

=== YouLose ===
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
You didn't get most of the orders correctly! Do you want to try again?
+[Try Again?]
    ->MiniGame
+[Nevermind I am Tired]
    ->badChoice0("choiceItem8")
    
=== badChoice0(choiceItem) ===
~playerChoice = choiceItem
~badChoicesCounter += 1
#speaker:Narrator  #portrait:NingasKugon #layout:Default #voiceover:default
You Have Obtained <color="red"><b>NINGAS COGON!</b>
    ->NextDialogue4
=== NextDialogue4 ===
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT17
Oh! You're done already? You're fast! How did the deliveries go? 

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT18
I hope they got it immediately and would enjoy my cooking.

+[It went good. They properly received the food and it looks like they are happy with it.]
    ~goodChoicesCounter += 1
    ->NextDialogue5
+[It's done. Make sure the food that you will give me tastes good.]
    ~badChoicesCounter += 1
    ->NextAngryDialogue2
+[They received it. Where is the free food?]
    ~badChoicesCounter += 1
    ->NextAngryDialogue2

=== NextDialogue5 ===
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT19
I'm glad that they liked it. I hope they come back here to eat again.
->NextDialogue6

=== NextAngryDialogue2 ===
#speaker:Lola Tindera  #portrait:Lola_Angry_Talking #layout:Default #voiceover:LT20
Don't rush! Here is the free food, and that tastes good, don't worry.
->NextDialogue6

=== NextDialogue6 ===
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT21
Thanks again kid. You really were a big help today. 
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT22
Come back here again to eat okay? Also, tell your mother to buy food from here. 
#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT23
Until next time!

+[Thank you too for the free food! Mano po lola, goodbye!]
    ~goodChoicesCounter += 1
    ->goodChoice4("choiceItem10")
+[Okay I'll go now, I feel tired. Bye.]
    ~goodChoicesCounter += 1
    ~playerProgress += 1
    ->EndDialogue

 === goodChoice4(choiceItem) ===
~playerChoice = choiceItem
~playerProgress += 1
#speaker:Narrator  #portrait:RespectForTheElderly #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>RESPECT FOR THE ELDERLY!</b>
    ->EndDialogue

=== EndDialogue ===
~karinderyaEnd = true
#speaker:Lola Tindera  #portrait:Lola_Default #layout:Default #voiceover:default
Go roam the streets and talk to other people


->END
