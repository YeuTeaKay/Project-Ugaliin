INCLUDE globals.ink

{ playerProgress == 5: -> homeEnd}
{ playerProgress >= 1: -> exploreDialogue}


->homeStart

=== homeStart ===
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
A new beginning starts for Luad and their mother as they recently moved to their new home.


#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
Their neighbors helped them move in, making them comfortable in the Barangay. 


#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
They are about to finish tidying up their house, so Luad’s mother tells Luad to go out and explore their community.

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M0
Thank goodness! We are about to finish tidying up so we can rest after this.

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M1
Luad my child, are you done cleaning your room? Don’t tire yourself, rest up if you need to.

#speaker:Mother  #portrait:Mother_Default #layout:Default #voiceover:M2
I’m close to done in fixing up our house so we can relax a bit after this.

+[I’ll do the remaining housework mom so that you can already rest.]
    ~goodChoicesCounter += 1
    ->goodChoice("choiceItem3")
  
+[Finally! We’ve been doing this for ages!]
    ~badChoicesCounter += 1
    ->NextDialogue1

    
=== goodChoice(choiceItem) ===
~playerChoice = choiceItem
#speaker:Item Received  #portrait:CloseFamilyTies #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>CLOSE FAMILY TIES!</b>
    ->NextDialogue1

=== NextDialogue1 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M3
I know that you're tired, so I'll take care of things around here. Don't worry, there's just a few chores left.
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M4
Your Tita Grace lives nearby, why don't you visit them? I'm sure she'll be happy seeing you.

+[Are you sure? Okay, I'll visit Tita Grace later.]
    ~goodChoicesCounter += 1
    ->NextDialogue2
  
+[I'll go there next time. They're just close by.]
    ~badChoicesCounter += 1
    ->badChoice("choiceItem7")

=== badChoice(choiceItem) ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:Default #voiceover:M5
What are you talking about? That's your Tita, go visit them immediately.

~playerChoice = choiceItem
#speaker:Item Received  #portrait:Manana #layout:Default #voiceover:default
You Have Obtained <color="red"><b>MANANA HABIT!</b>
    ->NextDialogue2

=== NextDialogue2 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M6
Alright, go around the Barangay first so that we can get to know them and so that they’ll know we have arrived.
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M7
I’ll take care of everything here at home. This is the list of places you should visit.

+[Okay mother I’ll take care of this.]
    ~goodChoicesCounter += 1
    ~playerProgress += 1
    ->exploreDialogue
+[Fiiiine..]
    ~badChoicesCounter += 1
    ~playerProgress += 1
    ->exploreDialogue
    
=== exploreDialogue ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:default
Go explore the street and talk to the neighbors!
->DONE

=== homeEnd ===
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
After exploring the barangay, Luad went home and greeted their mother. 

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
They talked about their experiences while going around the places in their community.

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M8
Oh Luad, how did going around the barangay go? Have you visited every place on the list I gave you?

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M9
You seem tired, come and rest here. Tell me what you saw and who you met.

+[It was fun! I met a lot of people and they were very nice.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue0
+[It was okay. I went to every place on the list.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue0
    
=== homeEndDialogue0 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M10
That's good, and it looks like you had a nice experience go around our barangay.
    ->homeEndDialogue1
    
=== homeEndAngryDialogue0 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:Default #voiceover:M11
Did you not mingle with them? They might think badly of us if your interaction with them did not go well.
    ->homeEndDialogue1
    
=== homeEndDialogue1 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M12
You just got home in time, I'm done with the housework. Have you thanked our neighbor who helped us earlier?

+[Yes, he told me that he can also help with other things in the house.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue2
+[Yes, and he wants to help again, but he might make us pay extra next time.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue1

=== homeEndDialogue2 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M13
Thank god we have someone who can help with the difficult work here in the house.
    ->homeEndDialogue3

=== homeEndAngryDialogue1 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:Default #voiceover:M14
Don't be quick to judge him. He looks like a nice person when he helped us.
    ->homeEndDialogue3
    
=== homeEndDialogue3 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M15
Your aunt and cousin, how are they? You haven't seen them for ages. Is there situation there good?

+[They're fine, I talked well with Tita and played with Ellie.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue4
+[They're okay, still them. There's nothing new.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue2

=== homeEndDialogue4 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M16
Next time, let's visit them again and eat there. I'm sure they'll be happy to see us.
->homeEndDialogue5

=== homeEndAngryDialogue2 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:Default #voiceover:M17
Don't be like that with your relatives! Oh I hope they're doing well over there.
->homeEndDialogue5

=== homeEndDialogue5 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M18
Oh did you pass by the Barangay Hall? The people there need to know if we have arrived. We might need to take care of a few things with them.

+[The Barangay Captain gave me a warm welcome.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue6
+[It looks like they don't have time for me earlier.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue3
    
=== homeEndDialogue6 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M19
I'll just go there next time because I know there are some papers that need to be submitted.
->homeEndDialogue7

=== homeEndAngryDialogue3 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:Default #voiceover:M20
Maybe they're just busy doing something. Their job is to maintain the quality of our Barangay.
->homeEndDialogue7

=== homeEndDialogue8 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M21
Do you know where we can buy food? I heard that the food at the eatery of Lola Tindera tastes good.
+[Yes, it's just nearby. The food cooked by Lola Tindera really is delicious.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue9
+[I passed by, and was forced to help the vendor. That's why I got tired.]
    ~badChoicesCounter += 1
    ->homeEndAngryDialogue4

=== homeEndDialogue7 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M22
Is that so? Okay, we'll but there again so that we can taste the other food cooked by Lola.
->homeEndDialogue9

=== homeEndAngryDialogue4 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:Default #voiceover:M23
It's okay to help, especially since we're new here. I just hope your help did well for them.
->homeEndDialogue9

=== homeEndDialogue9 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M24
Based on what I've heard from you, it looks like your exploration was meaningful here in the barangay. 
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M25
I hope we'll have a good life here, and I think it will be. We're near our family, we have good neighbors
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M26
and the people in the barangay hall are active in bettering our community.

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M27
What do you think?

+[We'll be happy here mom! I'm sure of it!]
    ~goodChoicesCounter += 1
    ~badChoicesCounter += 1
    ->homeEndDialogue10
+[I really hope so mom.]
    ~badChoicesCounter += 1
    ~badChoicesCounter += 1
    ->homeEndDialogue10
    
=== homeEndDialogue10 ===

{ goodChoicesCounter >= 20: -> HappyFiesta }
{ goodChoicesCounter <= 20: -> RollCredits1 }

=== HappyFiesta ===
#speaker:Doorbell   #portrait:Default #layout:Default #voiceover:default
DING DONG!

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M28
Huh? Who would that be. Wait, coming!

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:TG15
Sis! How are you? 

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:TG16
I thought I would pass by here to see how is moving in coming along. It's good that your moving went well. 

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:TG17
Visit us next time okay! The people from our barangay are also here.

#speaker:Kapit Bahay  #portrait:KapitBahay_Talking #layout:Default #voiceover:KB12
Hello! Are you guys good here? If you need any lifting or if you need fixing here in you house or anything at all, I'm just here around, just call me.

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover:LT24
Thank goodness for your child because if it weren't for them, I don't know what to do with the karinderya. Here, we still have a lot of food left from our eatery, it's all yours.

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:Default #voiceover:BG20
Welcome to our barangay! I do apologize that we just visited now, the fiesta is near that's why the people around are busy.

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:Default #voiceover:BG21
Your arrival is in impeccable timing! We're going to celebrate your arrival with the fiesta, so that you can feel the warm welcome of our community.

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M29
Thank you very much everyone for coming! I do hope that we can also help in making our barangay a better place for everyone. 

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M30
Me and my child are glad that we are in this community filled with wonderful people like you. Isn't that right Luad?

+[For sure! We are excited to live here with you guys.]
    ~goodChoicesCounter += 1
    ->homeEndDialogue11
+[I guess that's fine. Just don't bother us that much.]
    ~badChoicesCounter += 1
    ->homeEndDialogue12

=== homeEndDialogue11 ===
#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M31
We sure are! You guys have been nice to us even though we just got here. Thank you again!
    ->homeEndDialogue13
=== homeEndDialogue12 ===
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:Default #voiceover:M32
Luad! Don't be like that to everyone! They're good people who came all the way here just to greet us. Show a little courtesy!
    ->homeEndDialogue13

=== homeEndDialogue13 ===
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:TG18
Don't worry sis! We understand and we are always here to help you guys.

#speaker:Kapit Bahay  #portrait:KapitBahay_Talking #layout:Default #voiceover:KB13
Yep! So let's get on with the fiesta!

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:Default #voiceover:BG22
Before the actual fiesta, let's have a house warming first!

#speaker:Lola Tindera  #portrait:Lola_Talking #layout:Default #voiceover::LT25
Okay 'Cap! I got the food, so eat up!

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:TG19
I'll help you prepare Lola.

#speaker:Kapit Bahay  #portrait:KapitBahay_Talking #layout:Default #voiceover:KB14
I'll fix the set up over here.

#speaker:Barangay Captain  #portrait:Barangay_Talking #layout:Default #voiceover:BG23
Don't worry ma'am and Luad, we'll take care of this. Just go be comfortable with everyone. Again, we would like to welcome you guys to our barangay!

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M33
Oh thank you, thank you so much! You guys are so nice! How about it Luad?

#speaker:Mother  #portrait:Mother_Talking #layout:Default #voiceover:M34
What do you think of our barangay now? We are going to have so much fun and I can't wait to be part of something just like this.

+[Same thoughts mom! I can't wait for the fiesta too!]
    ~goodChoicesCounter += 1
    ->EndingChoice("choiceItem4")
+[It's okay mom, I hope everything goes well.]
    ~badChoicesCounter += 1
    ->RollCredits2
=== EndingChoice(choiceItem) ===
~playerChoice = choiceItem
#speaker:Item Received  #portrait:FiestaGrande #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>Fiesta Grande!</b>
~Ending = "Fiesta Grande"
    ->RollCredits2

=== RollCredits1 ===
~Ending = "Home Coming"
~EndGame = true
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
And so, Luad and their mother continue to work on the house as they put the finishing touches and make themselves comfortable in their new home. 

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
Luad reflects on their experiences while exploring the barangay, feeling they can adjust well and become one with the community.

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
Mother ensures everything is in place, putting together a cozy home for them to live in. 
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
With their hopes up, they look forward to a brand new beginning in their new home. 

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
They know that there will be challenges ahead, but there are people around them who are ready to help them in times of need.

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
WELCOME TO THE BARANGAY!
->END

=== RollCredits2 ===
~EndGame = true
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
Everyone they know in the barangay is here to greet them, and give them a warm welcome.

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
They have family nearby to share everything with, neighbors who are trustworthy and looks out for them,

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
Elders who give them the support they can for the community,and leadership in the barangay that is dependable.

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
Luad and their mother feels very comfortable living in a place where these people exist.

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
With their hopes up, they look forward to a brand new beginning in their new home. 

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
They know that there will be challenges ahead, but there are people around them who are ready to help them in times of need.

#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
HAPPY FIESTA! WELCOME TO THE BARANGAY!


->END