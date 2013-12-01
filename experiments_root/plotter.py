import os
import sys
import matplotlib.pyplot as plt

def get_q_h_data(base_folder, q_time_file, h_time_file):
	h = []
	q = []
	for root, dirs, files in os.walk(base_folder):
		for d in dirs:
			q_f_path = os.path.join(base_folder, d, q_time_file)
			h_f_path = os.path.join(base_folder, d, h_time_file)
			with open(q_f_path, 'r') as f:
				q.append(float(f.readline().strip()))
			with open(h_f_path, 'r') as f:
				h.append(float(f.readline().strip()))
	return q, h


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

	random_folders_path = os.path.join(experiment_folder, random_folder)
	q_random_times, h_random_times = get_q_h_data(random_folders_path, q_time_file, h_time_file)

	asc_folders_path = os.path.join(experiment_folder, asc_folder)
	q_asc_times, h_asc_times = get_q_h_data(asc_folders_path, q_time_file, h_time_file)

	desc_folders_path = os.path.join(experiment_folder, asc_folder)
	q_desc_times, h_desc_times = get_q_h_data(desc_folders_path, q_time_file, h_time_file)

	plt.plot(q_random_times, c='b', title='Quicksort with random array')
	plt.plot(q_asc_times, c='b', title='Quicksort with asc array')
	plt.plot(q_asc_times, c='b', title='Quicksort with desc array')

	plt.plot(h_random_times, c='g', title='Heapsort with random array')
	plt.plot(h_asc_times, c='b', title='Heapsort with asc array')
	plt.plot(h_asc_times, c='b', title='Heapsort with desc array')

	plt.show()