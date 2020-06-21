octave = 1
count = 0
note = 0


def fnote(count):
    if count == 0:
        return "a"
    if count == 1:
        return "bb"
    if count == 2:
        return "b"
    if count == 3:
        return "c"
    if count == 4:
        return "db"
    if count == 5:
        return "d"
    if count == 6:
        return "eb"
    if count == 7:
        return "e"
    if count == 8:
        return "f"
    if count == 9:
        return "gb"
    if count == 10:
        return "g"
    if count == 11:
        return "ab"

for i in range(109 - 21):
    if len(fnote(note)) == 1:
        print(("if (note ==\"") + str(i + 21) + ("\") "), fnote(note) + (str(octave)) + (".Image = Properties.Resources.red;"))
    else:
        print(("if (note ==\"") + str(i + 21) + ("\") "), fnote(note) + (str(octave)) + (".Image = Properties.Resources.blackred;"))
    note = note + 1
    if note == 12:
        octave = octave + 1
        note = 0

    
