INCLUDE globals.ink

{ playerProgress == 0: -> homeStart}

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

+[Are you sure? Okay, I'll visit Tita Grace later.] #portrait:Mother_Default
    ~goodChoicesCounter += 1
    ->NextDialogue2
  
+[I'll go there next time. They're just close by.] #portrait:Mother_Angry_Idle
    ~badChoicesCounter += 1
    ->badChoice("choiceItem1")

=== badChoice(choiceItem) ===
~playerChoice = choiceItem
#speaker:Mother  #portrait:Mother_Angry_Talking #layout:left #voiceover:default
What are you talking about? That's your Tita, go visit them immediately.\
#speaker:Narrator  #portrait:Default #layout:left #voiceover:default
You Have Obtained <color="red"><b>MANANA HABIT!</b>
    ->NextDialogue2

=== NextDialogue2 ===
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
Alright, go around the Barangay first so that we can get to know them and so that they’ll know we have arrived.
#speaker:Mother  #portrait:Mother_Talking #layout:left #voiceover:default
I’ll take care of everything here at home. This is the list of places you should visit.

+[Okay mother I’ll take care of this.] #portrait:Mother_Default
    ~goodChoicesCounter += 1
    ~playerProgress = 2
    ->exploreDialogue
+[Fiiiine..] #portrait:Mother_Default
    ~badChoicesCounter += 1
    ~playerProgress = 2
    ->exploreDialogue
    
=== exploreDialogue ===
Go explore our street and talk to the neighbors!

->END