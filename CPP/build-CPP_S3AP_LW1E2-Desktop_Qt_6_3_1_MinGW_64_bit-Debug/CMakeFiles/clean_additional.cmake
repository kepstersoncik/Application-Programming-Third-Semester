# Additional clean files
cmake_minimum_required(VERSION 3.16)

if("${CONFIG}" STREQUAL "" OR "${CONFIG}" STREQUAL "Debug")
  file(REMOVE_RECURSE
  "CMakeFiles\\CPP_S3AP_LW1E2_autogen.dir\\AutogenUsed.txt"
  "CMakeFiles\\CPP_S3AP_LW1E2_autogen.dir\\ParseCache.txt"
  "CPP_S3AP_LW1E2_autogen"
  )
endif()
