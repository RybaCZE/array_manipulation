static void wait() {
    Console.Write("press enter to continue");
    string unknown_number = Console.ReadLine();
    return;
}

static int? str_to_int(out string end) {
    int fn_num = 0;
    string unknown_number = Console.ReadLine();
    if (unknown_number == ".") {
        end = ".";
        return null;
    }
    try {
        fn_num = Int32.Parse(unknown_number);
    } catch (FormatException e) {
        //Console.WriteLine(e.Message, "and try again");
        //str_to_int();
        end = "";
        return null;
    }

    end = "";
    return fn_num;
}






static int count_non_null_items(ref int?[] arr) {

    int counter = 0;
    foreach (int i in arr) {
        if (i > 0 || i < 0) {
            counter += 1;
        }
    }
    return counter;
}


static int get_array_size(ref int?[] arr) {
    return arr.Length;
}



static void remove_non_int_items(ref int?[] arr) {
    List<int?> ans = new List<int?>();
    foreach (var item in ans) {
        if (item != null) {
            ans.Add(item);
        } else {
            continue;
        }
    }
    arr = ans.ToArray();
    return;
}



static void deleting_an_element(ref int?[] arr, int index) {
    List<int?> ans = arr.ToList();
    ans.RemoveAt(index);
    arr = ans.ToArray();

}



static bool change_array_index_value(ref int?[] arr, int index, int new_value) {
    if (index >= 0 && index < arr.Length) {
        arr[index] = new_value;
        return true;
    } else {
        Console.WriteLine("index out of range.\n Try again");
        return false;
    }

}

static void inserting_an_element(ref int?[] arr, int index, int value) {
    List<int?> ans = new List<int?>();
    int counter = 0;
    foreach (int i in arr) {
        if (counter == index) {
            ans.Add(value);
        }
        ans.Add(i);
        counter += 1;



    }
    arr = ans.ToArray();
    return;
}



static int?[] create_arr(ref int?[] arr) {
    string end = "";
    int? idk = 0;
    List<int?> ans = new List<int?>();
    while (true) {

        if (end == ".") {
            break;
        } else {
            idk = str_to_int(out end);
            ans.Add(idk);
            continue;
        }
    }
    int?[] a = arr.Concat(ans).ToArray();
    return a;
}

static int? get_value_of_an_element(ref int?[] arr, int index) {
    if (index >= 0 && index < arr.Length) {
        return arr[index];
    } else {
        Console.WriteLine("index out of range.");
        return null;
    }

}


static void main() {
    string end = "";
    int?[] arr = { };
    Console.WriteLine("Create an array and end it by typing '.'");
    arr = create_arr(ref arr);
    int index = 0;
    int ans = 0;
    string idk = "";
    bool success = false;
    while (true) {
        foreach (int? x in arr) {
            Console.Write($"{x}, ");
        }
        Console.Write("\n");
        int selection = 0;
        Console.WriteLine("1) Přidání prvku");
        Console.WriteLine("2) Změna hodnoty prvku - pole musí změnit velikost, pokud žádám o zápis mimo jeho aktuální velikost");
        Console.WriteLine("3)Získání hodnoty prvku - je potřeba vyřešit, co se má stát, pokud požádám o prvek na indexu mimo aktuální velikost pole");
        Console.WriteLine("4) Odstranění prvku na daném indexu a přesunutí následujících prvků na jeho místo");
        Console.WriteLine("5) Vložení prvku na určený index a posunutí ostatních prvků tak, aby pro něj vzniklo místo");
        Console.WriteLine("6) Setřesení pole tak, aby z pole zmizely díry z prázdných prvků");
        Console.WriteLine("7) Získání velikosti pole");
        Console.WriteLine("8) Získání počtu nenulových prvků");
        Console.WriteLine("9) Konec programu");
        Console.Write("select what you want: ");
        try {
            selection = str_to_int(out end).Value;
        } catch {
            selection = 0;
        }
        switch (selection) {
            case 1:
                arr = create_arr(ref arr);
                idk = "array";
                break;
            case 2:
                Console.Write("index: ");
                index = str_to_int(out end).Value;
                Console.Write("new value: ");
                int value = str_to_int(out end).Value;
                success = change_array_index_value(ref arr, index, value);
                idk = "bool";
                break;
            case 3:
                Console.Write("index: ");
                index = str_to_int(out end).Value;
                Console.Write("value: ");
                ans = get_value_of_an_element(ref arr, index).Value;
                idk = "int";
                break;

            case 4:
                Console.Write("index: ");
                index = str_to_int(out end).Value;
                deleting_an_element(ref arr, index);
                idk = "array";
                break;
            case 5:
                Console.Write("index: ");
                index = str_to_int(out end).Value;
                Console.Write("value: ");
                value = str_to_int(out end).Value;
                inserting_an_element(ref arr, index, value);
                idk = "array";
                break;
            case 6:
                remove_non_int_items(ref arr);
                idk = "array";
                break;
            case 7:
                ans = get_array_size(ref arr);
                idk = "int";
                break;
            case 8:
                ans = count_non_null_items(ref arr);
                idk = "int";
                break;
            case 9:
                Environment.Exit(1);
                break;
            case 0:
                Console.WriteLine("invalid input");
                continue;
            default:
                Console.WriteLine("invalid input");
                continue;
        }
        if (idk == "array") {
            Console.WriteLine("array: ");
            foreach (int? i in arr) {
                Console.Write(i + " ,");
            }
            Console.WriteLine();
        } else if (idk == "int") {
            Console.WriteLine(ans);
        } else if (idk == "bool") {
            Console.WriteLine(success);
        }



    }
}




main();
