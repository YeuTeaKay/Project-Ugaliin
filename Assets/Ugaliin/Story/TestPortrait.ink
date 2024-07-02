INCLUDE globals.ink

{ playerProgress == 0: -> main}
{ playerProgress == 1: -> secondDialogue}
{ playerProgress == 2: -> removeItemChoice}
{ playerProgress == 3: -> defaultEndDialogue}


-> main

=== main ===
Hay salamat! Kaunti nalang ang mga gawain #speaker:Mother #background:Player_House #portrait:Mother_Default #layout:left #voiceover:test
kaya pwede na tayo magpahinga pagkatapos nito.
+ [Ako na po sa mga natitirang gawain ‘nay para makapagpahinga na po kayo.]
    -> chosen
+ [Mabuti naman! Kanina pa tayo naglilinis eh.]
    -> chosen

=== chosen ===

Sige heto anak, libutin mo muna ang barangay parang
makilala natin sila at makilala rin nila tayo. Ako na ang bahala dito sa bahay.
Ito ang listahan ng mga dapat mong puntahan.


+[Hayy sige na nga.]

    ->importantChoice("choiceItem0")

+[Sige po nay ako na bahala dito sa listahan.]

    ->importantChoice("choiceItem1")

=== importantChoice(choiceItem) ===
~playerChoice = choiceItem
->firstDialogue


=== firstDialogue ===
Batiin mo yung mga kapitbahay natin para makilala mo ng sila  #speaker:Mother  #portrait:Mother_Default #layout:left
~playerProgress = 1
-> secondDialogue

=== secondDialogue ===
this is the second dialogue #speaker:Mother #background:Player_House #portrait:Mother_Default #layout:left #voiceover:test
->removeItemChoice

=== removeItemChoice ===
this is the second dialogue #speaker:Mother #background:Player_House #portrait:Mother_Default #layout:left #voiceover:test
~playerProgress = 2
+ [Remove Item 0] 
    -> removeItem("removeItem0")

+ [Remove Item 1]
    -> removeItem("removeItem1")

+ [Remove Item 2]
    -> removeItem("removeItem2")

=== removeItem(itemToRemove) ===
~playerChoice = itemToRemove
~playerProgress = 2
-> defaultEndDialogue

=== defaultEndDialogue ====
~playerProgress = 3
this is the default end dialogue #speaker:Mother #background:Player_House #portrait:Mother_Default #layout:left #voiceover:test
->END
