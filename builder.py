import os.path, os
import shutil

LETTERS = map(chr, range(ord('A'), ord('L')))
TEMPLATE_FILE = 'template' 
# python work folder

os.chdir('py')
py_template_file = os.path.join(os.getcwd(), TEMPLATE_FILE + '.py')

if not os.path.exists(py_template_file):
    print(f'Can\'t find python template file with name "{py_template_file}".')
else:
    for letter in LETTERS:
        new_file = os.path.join(os.getcwd(), letter + '.py')
        shutil.copy2(py_template_file, new_file)
