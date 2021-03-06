#!/bin/env python

"""
This script convert pixel from image to character:
	x:  skeleton block
	_:  empty (layer 0)

	0:  black
	1:  dark
	f0: flashing black

	2:  gray
	3:  light gray
	f2: flashing gray

	4:  silver
	5:  white
	f4: flashing white

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

COL2STR_BG = {
		"#000000ff": "x",
		"#ecf0f1ff": "_",
		}

COL2STR = {
		"#2c3e50ff": "0",
		"#34495eff": "1",
		"#000000ff": "f0",

		"#7f8c8dff": "2",
		"#95a5a6ff": "3",
		"#808080ff": "f2",

		"#bdc3c7ff": "4",
		"#ecf0f1ff": "5",
		"#ffffffff": "f4",

		"#16a085ff": "c",
		"#1abc9cff": "C",
		"#00ffffff": "fc",

		"#27ae60ff": "g",
		"#2ecc71ff": "G",
		"#008000ff": "fg",

		"#2980b9ff": "b",
		"#3498dbff": "B",
		"#0000ffff": "fb",

		"#8e44adff": "m",
		"#9b59b6ff": "M",
		"#ff00ffff": "fm",

		"#f39c12ff": "y",
		"#f1c40fff": "Y",
		"#ffff00ff": "fy",

		"#d35400ff": "o",
		"#e67e22ff": "O",
		"#ffa500ff": "fo",

		"#c0392bff": "r",
		"#e74c3cff": "R",
		"#ff0000ff": "fr",

		"#ffffff00": "_",
		"#00000000": "_",
		}

def get_script_path():
	return os.path.dirname(os.path.realpath(sys.argv[0]))

SCRIPT_DIR = get_script_path()
MAP_DIR = os.path.join(SCRIPT_DIR, 'maps')
MAP_PATH = os.path.join(SCRIPT_DIR, 'maps', '{}')

class ColorNotFoundError(Exception):
	pass


def get_filename(file):
	""" get filename and exclude its extension """
	return os.path.splitext(file)[0]

def chunk_list(a, n):
	""" chunk list a into n sublists """
	k, m = divmod(len(a), n)
	return list((a[i * k + min(i, m):(i + 1) * k + min(i + 1, m)] for i in range(n)))

def rgb_to_hex(color):
	"""Convert an rgb color to hex."""
	return "#%02x%02x%02x%02x" % (*color,)

def is_bg(file):
	""" if image file is background map """
	return file.endswith('_bg.png')

def ls_png():
	return [file for file in os.listdir(MAP_DIR) if MAP_PATH.format(file).endswith('.png')
			and not is_bg(file)
			and os.path.isfile(MAP_PATH.format(file))]

def get_output_path(pngfile):
	jsonfile = get_filename(pngfile) + '.json'
	return MAP_PATH.format(jsonfile)

def generate_matrix(imgfile, color_to_str):
	""" convert pixel to str from image """
	img = Image.open(MAP_PATH.format(imgfile))

	pixels = list(img.getdata())
	_, height = img.size

	matrix = chunk_list(pixels, height)

	for row, pixel_row in enumerate(matrix):

		for column, _ in enumerate(pixel_row):
			matrix[row][column] = rgb_to_hex(matrix[row][column])

			if matrix[row][column].lower() in color_to_str:
				matrix[row][column] = color_to_str[matrix[row][column]]

			else:
				raise ColorNotFoundError("Color {} at ({}, {}) cannot be found color dictionary"
						.format(matrix[row][column], column, row))

	return matrix

def generate_empty_map(matrix):
	""" generate empty map filled with '_' """
	return [['_' for _ in range(len(matrix[0]))] for _ in range(len(matrix))]

def generate_map(imgfile):
	""" convert pixel to char from image in ${cwd}/maps/ """
	return generate_matrix(imgfile, COL2STR)

def generate_bg_map(imgfile):
	""" generate the skeleton map that one layer below """
	return generate_matrix(imgfile, COL2STR_BG)

def main():
	""" main function """
	data = {}

	for png_file in ls_png():
		print_prompt('convert to json map file from {}'.format(png_file))

		data['name'] = get_filename(png_file)
		data['layer1'] = generate_map(png_file)

		png_bg_file = get_filename(png_file) + '_bg.png'
		if os.path.isfile(MAP_PATH.format(png_bg_file)):
			data['layer0'] = generate_bg_map(png_bg_file)
		else:
			data['layer0'] = generate_empty_map(data['layer1'])

		with open(get_output_path(png_file), 'w') as file:
			json.dump(data, file, separators=(',',':'))

if __name__ == '__main__':
	main()

# vim: nofoldenable
