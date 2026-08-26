#pragma once
#include <windows.h>
#include <string>

// --- IL2CPP Types ---
typedef void* Il2CppDomain;
typedef void* Il2CppThread;
typedef void* Il2CppImage;
typedef void* Il2CppClass;
typedef void* Il2CppMethodPointer;
typedef void* Il2CppObject;
typedef void* Il2CppString;
typedef void* Il2CppArray;
typedef void* MethodInfo;

struct Vector3 {
    float x, y, z;
};

// --- IL2CPP Functions Typedefs ---
typedef Il2CppDomain* (*il2cpp_domain_get_t)();
typedef Il2CppThread* (*il2cpp_thread_attach_t)(Il2CppDomain* domain);
typedef void* (*il2cpp_domain_get_assemblies_t)(const Il2CppDomain* domain, size_t* size);
typedef Il2CppImage* (*il2cpp_assembly_get_image_t)(const void* assembly);
typedef Il2CppClass* (*il2cpp_class_from_name_t)(const Il2CppImage* image, const char* namespaze, const char* name);
typedef MethodInfo* (*il2cpp_class_get_method_from_name_t)(Il2CppClass* klass, const char* name, int argsCount);
typedef Il2CppObject* (*il2cpp_runtime_invoke_t)(const MethodInfo* method, void* obj, void** params, void** exc);
typedef void* (*il2cpp_object_get_class_t)(Il2CppObject* obj);
typedef void* (*il2cpp_class_get_type_t)(Il2CppClass* klass);
typedef void* (*il2cpp_type_get_object_t)(void* type);
typedef Il2CppString* (*il2cpp_string_new_t)(const char* str);
typedef void* (*il2cpp_resolve_icall_t)(const char* name);

// --- Resolver Class ---
class Il2CppResolver {
public:
    HMODULE hGameAssembly = NULL;

    il2cpp_domain_get_t il2cpp_domain_get;
    il2cpp_thread_attach_t il2cpp_thread_attach;
    il2cpp_domain_get_assemblies_t il2cpp_domain_get_assemblies;
    il2cpp_assembly_get_image_t il2cpp_assembly_get_image;
    il2cpp_class_from_name_t il2cpp_class_from_name;
    il2cpp_class_get_method_from_name_t il2cpp_class_get_method_from_name;
    il2cpp_runtime_invoke_t il2cpp_runtime_invoke;
    il2cpp_object_get_class_t il2cpp_object_get_class;
    il2cpp_class_get_type_t il2cpp_class_get_type;
    il2cpp_type_get_object_t il2cpp_type_get_object;
    il2cpp_string_new_t il2cpp_string_new;
    il2cpp_resolve_icall_t il2cpp_resolve_icall;

    bool Init() {
        hGameAssembly = GetModuleHandleA("GameAssembly.dll");
        if (!hGameAssembly) return false;

        il2cpp_domain_get = (il2cpp_domain_get_t)GetProcAddress(hGameAssembly, "il2cpp_domain_get");
        il2cpp_thread_attach = (il2cpp_thread_attach_t)GetProcAddress(hGameAssembly, "il2cpp_thread_attach");
        il2cpp_domain_get_assemblies = (il2cpp_domain_get_assemblies_t)GetProcAddress(hGameAssembly, "il2cpp_domain_get_assemblies");
        il2cpp_assembly_get_image = (il2cpp_assembly_get_image_t)GetProcAddress(hGameAssembly, "il2cpp_assembly_get_image");
        il2cpp_class_from_name = (il2cpp_class_from_name_t)GetProcAddress(hGameAssembly, "il2cpp_class_from_name");
        il2cpp_class_get_method_from_name = (il2cpp_class_get_method_from_name_t)GetProcAddress(hGameAssembly, "il2cpp_class_get_method_from_name");
        il2cpp_runtime_invoke = (il2cpp_runtime_invoke_t)GetProcAddress(hGameAssembly, "il2cpp_runtime_invoke");
        il2cpp_object_get_class = (il2cpp_object_get_class_t)GetProcAddress(hGameAssembly, "il2cpp_object_get_class");
        il2cpp_class_get_type = (il2cpp_class_get_type_t)GetProcAddress(hGameAssembly, "il2cpp_class_get_type");
        il2cpp_type_get_object = (il2cpp_type_get_object_t)GetProcAddress(hGameAssembly, "il2cpp_type_get_object");
        il2cpp_string_new = (il2cpp_string_new_t)GetProcAddress(hGameAssembly, "il2cpp_string_new");
        il2cpp_resolve_icall = (il2cpp_resolve_icall_t)GetProcAddress(hGameAssembly, "il2cpp_resolve_icall");

        if (il2cpp_domain_get && il2cpp_thread_attach) {
            Il2CppDomain* domain = il2cpp_domain_get();
            if (domain) il2cpp_thread_attach(domain);
        }
        return true;
    }

    Il2CppImage* GetImage(const char* assemblyName) {
        size_t size;
        void** assemblies = (void**)il2cpp_domain_get_assemblies(il2cpp_domain_get(), &size);
        for (size_t i = 0; i < size; ++i) {
            Il2CppImage* image = il2cpp_assembly_get_image(assemblies[i]);
        }
        return NULL;
    }

    void* ResolveICall(const char* name) {
        if (il2cpp_resolve_icall) {
            return il2cpp_resolve_icall(name);
        }
        return NULL;
    }
};

extern Il2CppResolver g_Il2Cpp;
