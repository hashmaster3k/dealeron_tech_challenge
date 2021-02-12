using System;

class RoverNaviation {

  public static string getMovements() {
    Console.Write("Enter movements (excample LMLMLMLMM): ");
    string movements = Console.ReadLine();

    if (containsInvalidMovement(movements)) {
      do {
        Console.WriteLine("Movement string contains invalid movement. Try again.\n");
        Console.Write("Enter movements (excample LMLMLMLMM): ");
        movements = Console.ReadLine();
      } while (containsInvalidMovement(movements));
    }

    return movements;
  }

  public static bool containsInvalidMovement(string movements) {
    string allowableChars = "RLM";

    foreach (char movement in movements) {
      if (!allowableChars.Contains(movement.ToString())) {
        return true;
      }
    };

    return false;
  }

  public static string getHeading(int max_x, int max_y) {
    Console.Write("Enter a starting point and facing direction (example 1 2 N): ");
    string heading = Console.ReadLine();

    if (!validBounds(heading, max_x, max_y) || !validDirection(heading)) {
      do {
        Console.WriteLine("Invalid starting point or direction. Try Again.\n");
        Console.Write("Enter a starting point and facing direction (example 1 2 N): ");
        heading = Console.ReadLine();
      } while (!(validBounds(heading, max_x, max_y) && validDirection(heading)));
    }

    return heading;
  }

  public static bool validBounds(string heading, int max_x, int max_y) {
    int x = Int32.Parse(heading.Split(' ')[0]);
    int y = Int32.Parse(heading.Split(' ')[1]);

    return x <= max_x && x >= 0 && y <= max_y && y >= 0;
  }

  public static bool validDirection(string heading) {
    char face = heading.Split(' ')[2][0];

    if (face == 'N' || face == 'E' || face == 'S' || face == 'W') {
      return true;
    } else {
      return false;
    }
  }

  static void Main() {
    Console.WriteLine("Welcome to the Rover Navigation App!\n");

    Console.Write("Enter plateau grid (example 5x5): ");
    string gridString = Console.ReadLine();

    int x = Int32.Parse(gridString.Split('x')[0]);
    int y = Int32.Parse(gridString.Split('x')[1]);

    Rover rover = new Rover() { max_x = x, max_y = y };

    string heading = getHeading(x, y);
    string movements = getMovements();

    Console.WriteLine(rover.move(heading, movements));
  }
}
