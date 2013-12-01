import os
import sys
import matplotlib.pyplot as plt

if len(sys.argv) < 2:
	print 'Specify experiment folder. Syntax python plotter.py experiment_folder'	
else:
	random_folder = 'random'
	asc_folder = 'asc'
	desc_folder = 'desc'
	q_time_file = 'test_q_t.time'
	h_time_file = 'test_h_t.time'

	experiment_folder = sys.argv[1];

	print 'Information gathering: ', experiment_folder

	q_random_times = []
	h_random_times = []
	random_folders_path = os.path.join(experiment_folder, random_folder)

	for root, dirs, files in os.walk(random_folders_path):
		for d in dirs:
			q_f_path = os.path.join(random_folders_path, d, q_time_file)
			h_f_path = os.path.join(random_folders_path, d, h_time_file)
			with open(q_f_path, 'r') as f:
				q_random_times.append(float(f.readline().strip()))
			with open(h_f_path, 'r') as f:
				q_random_times.append(float(f.readline().strip()))

	q_asc_times = []
	h_asc_times = []
	asc_folders_path = os.path.join(experiment_folder, asc_folder)

	for root, dirs, files in os.walk(asc_folders_path):
		for d in dirs:
			q_f_path = os.path.join(asc_folders_path, d, q_time_file)
			h_f_path = os.path.join(asc_folders_path, d, h_time_file)
			with open(q_f_path, 'r') as f:
				q_asc_times.append(float(f.readline().strip()))
			with open(h_f_path, 'r') as f:
				h_asc_times.append(float(f.readline().strip()))

	q_desc_times = []
	h_desc_times = []
	desc_folders_path = os.path.join(experiment_folder, asc_folder)

	for root, dirs, files in os.walk(desc_folders_path):
		for d in dirs:
			q_f_path = os.path.join(desc_folders_path, d, q_time_file)
			h_f_path = os.path.join(desc_folders_path, d, h_time_file)
			with open(q_f_path, 'r') as f:
				q_desc_times.append(float(f.readline().strip()))
			with open(h_f_path, 'r') as f:
				h_desc_times.append(float(f.readline().strip()))

	plt.plot(q_random_times, c='b', title='Quicksort with random array')
	plt.plot(q_asc_times, c='b', title='Quicksort with asc array')
	plt.plot(q_asc_times, c='b', title='Quicksort with desc array')

	plt.plot(h_random_times, c='g', title='Heapsort with random array')
	plt.plot(h_asc_times, c='b', title='Heapsort with asc array')
	plt.plot(h_asc_times, c='b', title='Heapsort with desc array')

	plt.show()