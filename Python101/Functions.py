import turtle
turtle.shape("turtle")
turtle.speed("fastest")

def draw_triangle(side_length):
    for i in range(3):
        turtle.forward(side_length)
        turtle.left(120)


# Assign starting value
side_length = 50

# Forever loop
while True:
    draw_triangle(side_length)
    side_length += 5          # side_length = side_length + 5



turtle.mainloop()