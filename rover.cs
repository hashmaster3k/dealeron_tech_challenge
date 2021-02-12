using System;

public class Rover {
  public int max_x { get; set; }
  public int max_y { get; set; }

  public bool outOfBounds(int x, int y) {
    return x > max_x || x < 0 || y > max_y || y < 0;
  }

  public string move(string headingString, string movements) {
    int heading_x = Int32.Parse(headingString.Split(' ')[0]);
    int heading_y = Int32.Parse(headingString.Split(' ')[1]);
    char face = headingString.Split(' ')[2][0];

    foreach (char movement in movements) {
      if (face == 'N') {
        if (movement == 'R') {
          face = 'E';
        } else if (movement == 'L') {
          face = 'W';
        } else if (movement == 'M') {
          heading_y += 1;
        };
      } else if (face == 'E') {
        if (movement == 'R') {
          face = 'S';
        } else if (movement == 'L') {
          face = 'N';
        } else if (movement == 'M') {
          heading_x += 1;
        }
      } else if (face == 'S') {
        if (movement == 'R') {
          face = 'W';
        } else if (movement == 'L') {
          face = 'E';
        } else if (movement == 'M') {
          heading_y -= 1;
        }
      } else if (face == 'W') {
        if (movement == 'R') {
          face = 'N';
        } else if (movement == 'L') {
          face = 'S';
        } else if (movement == 'M') {
          heading_x -= 1;
        }
      }

      if (outOfBounds(heading_x, heading_y)) {
        return "Your movements led you out of bounds";
      }
    }

    return String.Concat($"\nYour rover's heading after it's movements are {heading_x} {heading_y} {face}");
  }
}
