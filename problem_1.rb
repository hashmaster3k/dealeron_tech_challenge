class Rover

  attr_reader :grid_x, :grid_y

  def initialize(start)
    @grid_x = start.split[0].to_i
    @grid_y = start.split[1].to_i
  end

  def move(heading, movement_string)
    location = [heading.split[0].to_i, heading.split[1].to_i]
    face = heading.split[2]
    movements = movement_string.chars

    return 'Starting location is out of bounds' if out_of_bounds?(location)

    until movements.empty? do
      if face == 'N'
        if movements.first == 'R'
          face = 'E'
        elsif movements.first == 'L'
          face = 'W'
        elsif movements.first == 'M'
          location[1] += 1
        end
        movements.shift
      elsif face == 'E'
        if movements.first == 'R'
          face = 'S'
        elsif movements.first == 'L'
          face = 'N'
        elsif movements.first == 'M'
          location[0] += 1
        end
        movements.shift
      elsif face == 'S'
        if movements.first == 'R'
          face = 'W'
        elsif movements.first == 'L'
          face = 'E'
        elsif movements.first == 'M'
          location[1] -= 1
        end
        movements.shift
      elsif face == 'W'
        if movements.first == 'R'
          face = 'N'
        elsif movements.first == 'L'
          face = 'S'
        elsif movements.first == 'M'
          location[0] -= 1
        end
        movements.shift
      else
        return 'Incorrect direction'
      end
    end

    "#{location[0]} #{location[1]} #{face}"
  end

  def out_of_bounds?(location)
    location[0] > @grid_x || location[1] > @grid_y
  end

end

rover = Rover.new('5 5')
puts rover.move('1 2 N', 'LMLMLMLMM')
puts rover.move('3 3 E', 'MMRMMRMRRM')
