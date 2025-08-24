using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementSystem
{
    internal class Opgavebeskrivelse
    {
        /*
            Afleveringsopgave
            Introduktion: I denne opgave skal du designe og implementere et objektorienteret system til at administrere en zoo. Systemet skal modellere forskellige dyr, deres bure, dyrepassere og grundlæggende interaktioner mellem dem. Opgaven er designet til at tage ca. 6-8 timer.

            Krav til systemet: Du skal implementere følgende klasser og funktionalitet:

            Beskriv de 4 OOP koncepter, med eksempler:

            Indkapsling (Encapsulation)
            Nedarvning (Inheritance)
            Polymorfi (Polymorfism)
            Abstraktion (Abstraction)
            1. Klasse: Animal (Abstrakt klasse)
            Attributter:

            name (str): Dyrets navn

            species (str): Dyrets art

            birthdate (datetime): Dyrets alder

            Metoder:

            make_sound(): Printer lyden dyret laver

            eat(): Printer at dyret spiser

            sleep(): Printer at dyret sover

            getage(): Udregner dyrets alder

            2. Klasser for specifikke dyr (nedarver fra Animal)
            Lion

            Elephant

            Giraffe

            Penguin

            Hver klasse skal have en unik sound-værdi og kan have ekstra funktioner, f.eks. hunt() for løven.

            3. Klasse: Enclosure
            Attributter:

            name (str): Navnet på buret

            size (int): Størrelsen på buret (m²)

            animals (list): Liste af dyr i buret

            Metoder:

            add_animal(animal): Tilføjer et dyr til buret

            remove_animal(animal): Fjerner et dyr fra buret

            list_animals(): Udskriver en liste af alle dyr i buret

            4. Klasse: Zookeeper
            Attributter:

            name (str): Dyrepasserens navn

            age (int): Dyrepasserens alder

            assigned_enclosure (Enclosure): Det bur, dyrepasseren har ansvar for

            Metoder:

            feed_animals(): Udskriver en besked om, at dyrene i buret fodres

            clean_enclosure(): Udskriver en besked om, at buret bliver rengjort

            5. Klasse: Zoo
            Attributter:

            name (str): Navnet på zooen

            enclosures (list): Liste over alle bure i zooen

            Metoder:

            add_enclosure(enclosure): Tilføjer et bur til zooen

            list_all_animals(): Udskriver en liste af alle dyr i zooen

            Ekstra udfordringer:

            Tilføj en Visitor-klasse, der kan besøge zoo og se dyrene.

            Udvid systemet med en daglig rutine, hvor dyrene bliver fodret, bure bliver rengjort, og dyrene laver lyde.

            Lav et Gui system, der gør det muligt at oprette/gemme/slette mv, via et menusystem.

            Lav et filsystem hvor data kan blive gemt.
        */
    }
}
