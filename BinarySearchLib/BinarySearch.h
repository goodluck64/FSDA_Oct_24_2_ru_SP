#pragma once

#ifdef CPPDYNAMICLIBRARYTEMPLATE_EXPORTS
#define BINARYSEARCHDLL_API __declspec(dllexport)
#else
#define BINARYSEARCHDLL_API __declspec(dllimport)
#endif

extern "C" BINARYSEARCHDLL_API int BinarySearch(int* array, int size, int value);
