import os
import sys
#import matplotlib.pyplot as plt


def get_q_h_data(base_folder, q_time_file, h_time_file):
	h = []
	q = []
	for root, dirs, files in os.walk(base_folder):
		f = 0
		for d in sorted(dirs, key = int):
			q_f_path = os.path.join(base_folder, d, q_time_file)
			h_f_path = os.path.join(base_folder, d, h_time_file)
			with open(q_f_path, 'r') as f:
				q.append(float(f.readline().strip()))
			with open(h_f_path, 'r') as f:
				h.append(float(f.readline().strip()))
	return q, h

def csv_output(csv_file_format, base_folder, data_list):
	csv_file_name = csv_file_format % base_folder
	with open(csv_file_name, 'w') as f:
		for data in data_list:
			f.write(','.join(map(str, data)) + '\n')



if len(sys.argv) < 2:
	print 'Specify experiment folder. Syntax python plotter.py experiment_folder'	
else:
	random_folder = 'random'
	asc_folder = 'asc'
	desc_folder = 'desc'
	q_time_file = 'test_q_t.time'
	h_time_file = 'test_h_t.time'
	experiment_folder = sys.argv[1];

	csv_file_format = 'results_' + experiment_folder + '_%s.csv'

	print 'Information gathering: ', experiment_folder

	random_folders_path = os.path.join(experiment_folder, random_folder)
	q_random_times, h_random_times = get_q_h_data(random_folders_path, q_time_file, h_time_file)


	asc_folders_path = os.path.join(experiment_folder, asc_folder)
	q_asc_times, h_asc_times = get_q_h_data(asc_folders_path, q_time_file, h_time_file)

	desc_folders_path = os.path.join(experiment_folder, desc_folder)
	q_desc_times, h_desc_times = get_q_h_data(desc_folders_path, q_time_file, h_time_file)

	csv_output(csv_file_format, random_folder, [q_random_times, h_random_times])
	csv_output(csv_file_format, asc_folder, [q_asc_times, h_asc_times])
	csv_output(csv_file_format, desc_folder, [q_desc_times, h_desc_times])
	csv_output(csv_file_format, 'all', [q_random_times, q_asc_times, q_desc_times, h_random_times, h_asc_times, h_desc_times])
	# plt.plot(q_random_times, c='b', title='Quicksort with random array')
	# plt.plot(q_asc_times, c='b', title='Quicksort with asc array')
	# plt.plot(q_asc_times, c='b', title='Quicksort with desc array')

	# plt.plot(h_random_times, c='g', title='Heapsort with random array')
	# plt.plot(h_asc_times, c='b', title='Heapsort with asc array')
	# plt.plot(h_asc_times, c='b', title='Heapsort with desc array')

	# plt.legend()
	# plt.show()