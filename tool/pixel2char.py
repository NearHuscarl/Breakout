#!/bin/env python

import json
import os

from PIL import Image

"""
This script convert pixel from image to character:
	0: black
	1: dark
	2: dark gray
	3: gray
	4: light gray
	5: white

	C: cyan
	c: light cyan

	G: green
	g: light green

	B: blue
	b: light blue

	M: magenta
	m: light magenta

	Y: yellow
	y: light yellow

	O: orange
	o: light orange

	R: red
	r: light red
"""


COLORMAP = {
		"#2c3e50": "0",
		"#34495e": "1",
		"#7f8c8d": "2",
		"#95a5a6": "3",
		"#bdc3c7": "4",
		"#ecf0f1": "5",
		"#16a085": "C",
		"#1abc9c": "c",
		"#27ae60": "G",
		"#2ecc71": "g",
		"#2980b9": "B",
		"#3498db": "b",
		"#8e44ad": "M",
		"#9b59b6": "m",
		"#f39c12": "Y",
		"#f1c40f": "y",
		"#d35400": "O",
		"#e67e22": "o",
		"#c0392b": "R",
		"#e74c3c": "r",
		}

def chunk_list(a, n):
	""" chunk list a into n sublists """
	k, m = divmod(len(a), n)
	return list((a[i * k + min(i, m):(i + 1) * k + min(i + 1, m)] for i in range(n)))

def rgb_to_hex(color):
	"""Convert an rgb color to hex."""
	color = color[0:3]
	return "#%02x%02x%02x" % (*color,)

def ls_png():
	return [file for file in os.listdir() if file.endswith('.png') and os.path.isfile(file)]

def get_output_path(pngfile):
	jsonfile = os.path.splitext(pngfile)[0] + '.json'
	return os.path.join(os.getcwd(), jsonfile)

def pixel2char(imgfile):
	""" convert pixel to char from image in cwd """
	img = Image.open(imgfile)

	pixels = list(img.getdata())
	_, height = img.size

	pixels = chunk_list(pixels, height)

	for row, pixel_row in enumerate(pixels):
		for column, _ in enumerate(pixel_row):
			pixels[row][column] = rgb_to_hex(pixels[row][column])
			if pixels[row][column] in COLORMAP:
				pixels[row][column] = COLORMAP[pixels[row][column]]

	data = {
			'color': COLORMAP,
			'matrix': pixels,
			}

	with open(get_output_path(imgfile), 'w') as file:
		json.dump(data, file, indent=3, sort_keys=True)

def main():
	""" main function """
	for file in ls_png():
		print('convert pixel2char for {}'.format(file))
		pixel2char(file)

if __name__ == '__main__':
	main()

# vim: nofoldenable
