INCLUDE globals.ink

{ playerProgress == 0: -> homeStart}
{ playerProgress <= 1: -> exploreDialogue}
{ playerProgress == 5: -> homeEnd}

->homeStart

=== homeStart ===
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
A new beginning starts for Luad and their mother as they recently moved to their new home.


#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
Their neighbors helped them move in, making them comfortable in the Barangay. 


#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
They are about to finish tidying up their house, so Luad’s mother tells <br> Luad to go out and explore their community.

#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Thank goodness! We are about to finish tidying up so we can rest after this.

#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Luad my child, are you done cleaning your room? Don’t tire yourself, rest up if you need to.

#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
I’m close to done in fixing up our house so we can relax a bit after this.

+[I’ll do the remaining housework mom so that you can already rest.]
    ~goodChoicesCounter += 1
    ->goodChoice("choiceItem0")
  
+[Finally! We’ve been doing this for ages!]
    ~badChoicesCounter += 1
    ->NextDialogue1

    
=== goodChoice(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="blue"><b>CLOSE FAMILY TIES!</b>
    ->NextDialogue1

=== NextDialogue1 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
I know that you're tired, so I'll take care of things around here. Don't worry, there's just a few chores left.
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Your Tita Grace lives nearby, why don't you visit them? I'm sure she'll be happy seeing you.

+[Are you sure? Okay, I'll visit Tita Grace later.]
    ~goodChoicesCounter += 1
    ->NextDialogue2
  
+[I'll go there next time. They're just close by.]
    ~badChoicesCounter += 1
    ->badChoice("choiceItem1")

=== badChoice(choiceItem) ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:left #voiceover:default
What are you talking about? That's your Tita, go visit them immediately.

~playerChoice = choiceItem
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="red"><b>MANANA HABIT!</b>
    ->NextDialogue2

=== NextDialogue2 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Alright, go around the Barangay first so that we can get to know them and so that they’ll know we have arrived.
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
I’ll take care of everything here at home. This is the list of places you should visit.

+[Okay mother I’ll take care of this.]
    ~goodChoicesCounter += 1
    ~playerProgress = 1
    ->exploreDialogue
+[Fiiiine..]
    ~badChoicesCounter += 1
    ~playerProgress = 1
    ->exploreDialogue
    
=== exploreDialogue ===
Go explore our street and talk to the neighbors!
->DONE

=== homeEnd ===
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
After exploring the barangay, Luad went home and greeted their mother. 

#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
They talked about their experiences while going around the places in their community.

#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Oh Luad, how did going around the barangay go? Have you visited every place on the list I gave you?

#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
You seem tired, come and rest here. Tell me what you saw and who you met.

+[It was fun! I met a lot of people and they were very nice.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue0
+[It was okay. I went to every place on the list.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue0
    
=== homeEndDialogue0 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
That's good, and it looks like you had a nice experience go around our barangay.
    ->homeEndDialogue1
    
=== homeEndAngryDialogue0 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:left #voiceover:default
Did you not mingle with them? They might think badly of us if your interaction with them did not go well.
    ->homeEndDialogue1
    
=== homeEndDialogue1 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
You just got home in time, I'm done with the housework. Have you thanked our neighbor who helped us earlier?

+[Yes, he told me that he can also help with other things in the house.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue2
+[Yes, and he wants to help again, but he might make us pay extra next time.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue1

=== homeEndDialogue2 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Thank god we have someone who can help with the difficult work here in the house.
    ->homeEndDialogue3

=== homeEndAngryDialogue1 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:left #voiceover:default
Don't be quick to judge him. He looks like a nice person when he helped us.
    ->homeEndDialogue3
    
=== homeEndDialogue3 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Your aunt and cousin, how are they? You haven't seen them for ages. Is there situation there good?

+[They're fine, I talked well with Tita and played with Ellie.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue4
+[They're okay, still them. There's nothing new.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue2

=== homeEndDialogue4 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Next time, let's visit them again and eat there. I'm sure they'll be happy to see us.
->homeEndDialogue5

=== homeEndAngryDialogue2 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:left #voiceover:default
Don't be like that with your relatives! Oh I hope they're doing well over there.
->homeEndDialogue5

=== homeEndDialogue5 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Oh did you pass by the Barangay Hall? The people there need to know if we have arrived. 
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
We might need to take care of a few things with them.

+[The Barangay Captain gave me a warm welcome.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue6
+[It looks like they don't have time for me earlier.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue3
    
=== homeEndDialogue6 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
I'll just go there next time because I know there are some papers that need to be submitted.
->homeEndDialogue7

=== homeEndAngryDialogue3 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:left #voiceover:default
Maybe they're just busy doing something. Their job is to maintain the quality of our Barangay.
->homeEndDialogue7

=== homeEndDialogue8 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Do you know where we can buy food? I heard that the food at the eatery of Lola Tindera tastes good.
+[Yes, it's just nearby. The food cooked by Lola Tindera really is delicious.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue9
+[I passed by, and was forced to help the vendor. That's why I got tired.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue4

=== homeEndDialogue7 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Is that so? Okay, we'll but there again so that we can taste the other food cooked by Lola.
->homeEndDialogue9

=== homeEndAngryDialogue4 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:left #voiceover:default
It's okay to help, especially since we're new here. I just hope your help did well for them.
->homeEndDialogue9

=== homeEndDialogue9 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Based on what I've heard from you, it looks like your exploration was meaningful here in the barangay. 
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
I hope we'll have a good life here, and I think it will be. We're near our family,
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
we have good neighbors, and the people in the barangay hall are active in bettering our community.
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
What do you think?

+[We'll be happy here mom! I'm sure of it!]
    ~goodChoicesCounter += 1
    ->homeEndDialogue10
+[I really hope so mom.]
    ~badChoicesCounter += 1
    ->homeEndDialogue10
    
=== homeEndDialogue10 ===

{ goodChoicesCounter >= 20: -> HappyFiesta }
{ goodChoicesCounter < 20: -> RollCredits }

=== HappyFiesta ===
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
*DING DONG!*

#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Huh? Who would that be. Wait, coming!

#speaker:Tita Grace  #portrait:Mother_Talking #layout:left #voiceover:default
Sis! How are you? I thought I would pass by here to see how is moving in coming along. It's good that your moving went well. 
#speaker:Tita Grace  #portrait:Mother_Talking #layout:left #voiceover:default
Visit us next time okay! The people from our barangay are also here.

#speaker:Kapit Bahay  #portrait:Mother_Talking #layout:left #voiceover:default
Hello! Are you guys good here? If you need any lifting or if you need fixing here in you house or anything at all, I'm just here around, just call me.

#speaker:Lola Tindera  #portrait:Mother_Talking #layout:left #voiceover:default
Thank goodness for your child because if it weren't for them, I don't know what to do with the karinderya. Here, we still have a lot of food left from our eatery, it's all yours.

#speaker:Barangay Captain  #portrait:Mother_Talking #layout:left #voiceover:default
Welcome to our barangay! I do apologize that we just visited now, the fiesta is near that's why the people around are busy. 
#speaker:Barangay Captain  #portrait:Mother_Talking #layout:left #voiceover:default
Your arrival is in impeccable timing! We're going to celebrate your arrival with the fiesta, so that you can feel the warm welcome of our community.

->RollCredits

=== RollCredits ===

->END