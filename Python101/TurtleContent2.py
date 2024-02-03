import turtle
import random

turtle.shape("turtle")
turtle.Screen().colormode(255)
turtle.Screen().bgcolor("#c7f0d2")
turtle.speed("fastest")

x_loc = -400
y_loc = 380

for step_y in range(15):
    for step_x in range(16):
        turtle.penup()
        turtle.goto(x_loc, y_loc)
        turtle.pendown()
        # Pick a random color
        r = random.randint(0, 255)
        g = random.randint(0, 255)
        b = random.randint(0, 255)
        turtle.color(r, g, b)
        turtle.begin_fill()
        for i in range(4):
            turtle.forward(50)
            turtle.right(90)
        turtle.end_fill()

        x_loc = x_loc + 50
    y_loc = y_loc - 50
    x_loc = -400

turtle.mainloop()