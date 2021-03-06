import os;

low = 1
high = 1
max_high = 100
step = 1
size = 1e6 + 1;

#gen_files_format
default_file_name = "test"
default_extension = "tst"
time_extension = "time"

random_files = "./random/%d/%s.%s"
asc_files = "./asc/%d/%s.%s"
desc_files = "./desc/%d/%s.%s"
file_formats = [random_files, asc_files, desc_files]

path_to_generator = '..\..\Bin\TestFileGenerator.exe'
generate_command_fotmat = '%s -l %d -n %d' %(path_to_generator, low, size) +' -h %d -o %d -f %s'

path_to_sorter = '..\..\Bin\SortApplication.exe'
q_sort_command_format = path_to_sorter + " -i %s -o %s -t %s -s 1"
h_sort_command_format = path_to_sorter + " -i %s -o %s -t %s -s 2"

while(high <= max_high):
	print high
	for i in xrange(0, len(file_formats)):
		cur_format = file_formats[i]

		gen_file_name = cur_format % (high, default_file_name, default_extension)
		gen_command = generate_command_fotmat % (high, i, gen_file_name)
		os.system(gen_command)
		print gen_file_name, ' generation Completed'
		
		q_result_file_name = cur_format % (high, default_file_name +'_q_r', default_extension)
		q_time_file_name = cur_format % (high, default_file_name +'_q_t', time_extension)
		q_sort_command = q_sort_command_format % (gen_file_name, q_result_file_name , q_time_file_name)
		os.system(q_sort_command)		
		print gen_file_name, ' quick sort Completed'
		
		h_result_file_name = cur_format % (high, default_file_name +'_h_r', default_extension)
		h_time_file_name = cur_format % (high, default_file_name +'_h_t', time_extension)
		h_sort_command = h_sort_command_format % (gen_file_name, h_result_file_name, h_time_file_name)
		os.system(h_sort_command)
		print gen_file_name, ' heap sort Completed'
		print '==========================================='
	high = high + step