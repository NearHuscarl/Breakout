#!/bin/env python

"""
This script convert pixel from image to character:
	0:  black
	1:  dark
	f0: flashing black

	2:  gray
	3:  light gray
	f2: flashing gray

	4:  silver
	5:  white

	C:  cyan
	c:  light cyan
	fc: flashing cyan

	G:  green
	g:  light green
	fg: flashing green

	B:  blue
	b:  light blue
	fb: flashing blue

	M:  magenta
	m:  light magenta
	fm: flashing magenta

	Y:  yellow
	y:  light yellow
	fy: flashing yellow

	O:  orange
	o:  light orange
	fo: flashing orange

	R:  red
	r:  light red
	fr: flashing orange
"""

import json
import os
import sys

SCRIPT_NAME = os.path.basename(__file__)

def print_prompt(string):
	print('{}> {}'.format(SCRIPT_NAME, string))

try:
	# pip install pillow
	from PIL import Image
except ImportError:
	print_prompt('PIL module not found. Aborting...')
	sys.exit(1)

COLORMAP = {
		"#2c3e50": "0",
		"#34495e": "1",
		"#000000": "f0",

		"#7f8c8d": "2",
		"#95a5a6": "3",
		"#808080": "f2",

		"#bdc3c7": "4",
		"#ecf0f1": "5",

		"#16a085": "C",
		"#1abc9c": "c",
		"#00ffff": "fc",

		"#27ae60": "G",
		"#2ecc71": "g",
		"#008000": "fg",

		"#2980b9": "B",
		"#3498db": "b",
		"#0000ff": "fb",

		"#8e44ad": "M",
		"#9b59b6": "m",
		"#ff00ff": "fm",

		"#f39c12": "Y",
		"#f1c40f": "y",
		"#ffff00": "fy",

		"#d35400": "O",
		"#e67e22": "o",
		"#ffa500": "fo",

		"#c0392b": "R",
		"#e74c3c": "r",
		"#ff0000": "fr",
		}

def get_script_path():
	return os.path.dirname(os.path.realpath(sys.argv[0]))

SCRIPT_DIR = get_script_path()
MAP_DIR = os.path.join(SCRIPT_DIR, 'maps')
MAP_PATH = os.path.join(SCRIPT_DIR, 'maps', '{}')

class ColorNotFoundError(Exception):
	pass


def chunk_list(a, n):
	""" chunk list a into n sublists """
	k, m = divmod(len(a), n)
	return list((a[i * k + min(i, m):(i + 1) * k + min(i + 1, m)] for i in range(n)))

def rgb_to_hex(color):
	"""Convert an rgb color to hex."""
	color = color[0:3]
	return "#%02x%02x%02x" % (*color,)

def ls_png():
	return [file for file in os.listdir(MAP_DIR) if MAP_PATH.format(file).endswith('.png') and os.path.isfile(MAP_PATH.format(file))]

def get_output_path(pngfile):
	jsonfile = os.path.splitext(pngfile)[0] + '.json'
	return MAP_PATH.format(jsonfile)

def pixel2char(imgfile):
	""" convert pixel to char from image in cwd """
	img = Image.open(MAP_PATH.format(imgfile))

	pixels = list(img.getdata())
	_, height = img.size

	pixels = chunk_list(pixels, height)

	for row, pixel_row in enumerate(pixels):

		for column, _ in enumerate(pixel_row):
			pixels[row][column] = rgb_to_hex(pixels[row][column])

			if pixels[row][column].lower() in COLORMAP:
				pixels[row][column] = COLORMAP[pixels[row][column]]

			else:
				raise ColorNotFoundError("Color {} at ({}, {}) cannot be found color dictionary"
						.format(pixels[row][column], row, column))

	data = {
			'color': COLORMAP,
			'matrix': pixels,
			}

	with open(get_output_path(imgfile), 'w') as file:
		json.dump(data, file, indent=3, sort_keys=True)

def main():
	""" main function """
	for file in ls_png():
		print_prompt('convert pixel2char for {}'.format(file))
		pixel2char(file)

if __name__ == '__main__':
	main()

# vim: nofoldenable
