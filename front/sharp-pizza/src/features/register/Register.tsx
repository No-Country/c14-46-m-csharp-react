import { z, ZodType } from 'zod';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import axios from 'axios';
import toast from 'react-hot-toast';

type FormData = {
  fullName: string;
  email: string;
  phoneNumber: string;
  password: string;
  confirmPassword: string;
  address: string;
};

const Register = () => {
  const navigate = useNavigate();

  const schema: ZodType<FormData> = z
    .object({
      fullName: z
        .string()
        .min(6, {
          message: 'El Nombre Completo debe tener al menos 6 caracteres',
        })
        .max(30),
      email: z
        .string()
        .email({ message: 'Dirección de correo inválida' })
        .min(6, {
          message: 'El correo debe tener al menos 6 caracteres',
        }),
      phoneNumber: z
        .string()
        .refine((value) => value.replace(/\D/g, '').length > 9, {
          message: 'Ingrese un número de teléfono válido',
        }),
      address: z
        .string()
        .min(6, { message: 'La dirección debe tener al menos 6 caracteres' }),
      password: z
        .string()
        .min(6, { message: 'La contraseña debe tener al menos 6 caracteres' }),
      confirmPassword: z
        .string()
        .min(6, { message: 'La contraseña debe tener al menos 6 caracteres' }),
    })
    .refine((data) => data.password === data.confirmPassword, {
      message: 'Las contraseñas no coinciden',
      path: ['confirmPassword'],
    });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });

  const submitData = (data: FormData) => {
    toast.promise(
      axios
        .post('http://localhost:3001/user', {
          name: data.fullName,
          password: data.password,
          role: 'user',
          phone: data.phoneNumber,
          email: data.email,
          address: data.address,
          urlImg: 'https://cdn-icons-png.flaticon.com/512/1144/1144760.png',
        })
        .then(() => {
          navigate('/login');
        }),
      {
        loading: 'Registrando...',
        success: 'Registrado con éxito 🍕️',
        error: 'Error en el proceso de registro. Por favor intente más tarde.',
      }
    );
  };

  return (
    <div className='flex items-center justify-center h-screen'>
      <form
        onSubmit={handleSubmit(submitData)}
        className='w-full max-w-md p-6 bg-gray-900 border border-gray-200 rounded-lg shadow-lg dark:bg-gray-900 dark:border-gray-700'
      >
        <h1 className='mb-4 text-2xl font-bold text-gray-900 dark:text-white'>
          Crear Cuenta
        </h1>
        <p className='mb-4 text-sm text-gray-700 dark:text-gray-400'>
          Rellena los siguientes campos para registrarte
        </p>
        <div className='mb-4 flex'>
          <div className='mr-2'>
            <label
              htmlFor='fullName'
              className='block mb-2 text-sm font-medium text-gray-700 dark:text-gray-400'
            >
              Nombre Completo
            </label>
            <input
              type='text'
              id='fullName'
              {...register('fullName')}
              placeholder='Nombre Completo...'
              className='w-full px-3 py-2 border border-gray-300 rounded-md dark:bg-gray-900 dark:text-white dark:border-gray-600 focus:outline-none focus:ring-blue-500 focus:border-blue-500'
              required
            />
            {errors.fullName && (
              <p className='text-red-500'>{errors.fullName.message}</p>
            )}
          </div>
          <div>
            <label
              htmlFor='email'
              className='block mb-2 text-sm font-medium text-gray-700 dark:text-gray-400'
            >
              Correo Electrónico
            </label>
            <input
              type='email'
              id='email'
              {...register('email')}
              placeholder='Alexis@gmail.com'
              className='w-full px-3 py-2 border border-gray-300 rounded-md dark:bg-gray-900 dark:text-white dark:border-gray-600 focus:outline-none focus:ring-blue-500 focus:border-blue-500'
              required
            />
            {errors.email && (
              <p className='text-red-500'>{errors.email.message}</p>
            )}
          </div>
        </div>
        <div className='mb-4 flex'>
          <div className='mr-2'>
            <label
              htmlFor='phone_number'
              className='block mb-2 text-sm font-medium text-gray-700 dark:text-gray-400'
            >
              Número de Teléfono
            </label>
            <input
              type='tel'
              id='phoneNumber'
              {...register('phoneNumber')}
              placeholder='555-123-4567'
              className='w-full px-3 py-2 border border-gray-300 rounded-md dark:bg-gray-900 dark:text-white dark:border-gray-600 focus:outline-none focus:ring-blue-500 focus:border-blue-500'
              required
            />
            {errors.phoneNumber && (
              <p className='text-red-500'>{errors.phoneNumber.message}</p>
            )}
          </div>
          <div>
            <label
              htmlFor='address'
              className='block mb-2 text-sm font-medium text-gray-700 dark:text-gray-400'
            >
              Dirección
            </label>
            <input
              type='text'
              id='address'
              {...register('address')}
              placeholder='Av Calle 123'
              className='w-full px-3 py-2 border border-gray-300 rounded-md dark:bg-gray-900 dark:text-white dark:border-gray-600 focus:outline-none focus:ring-blue-500 focus:border-blue-500'
              required
            />
            {errors.address && (
              <p className='text-red-500'>{errors.address.message}</p>
            )}
          </div>
        </div>
        <div className='mb-4'>
          <label
            htmlFor='password'
            className='block mb-2 text-sm font-medium text-gray-700 dark:text-gray-400'
          >
            Contraseña
          </label>
          <input
            type='password'
            id='password'
            {...register('password')}
            placeholder='********'
            className='w-full px-3 py-2 border border-gray-300 rounded-md dark:bg-gray-900 dark:text-white dark:border-gray-600 focus:outline-none focus:ring-blue-500 focus:border-blue-500'
            required
          />
          {errors.password && (
            <p className='text-red-500'>{errors.password.message}</p>
          )}
        </div>
        <div className='mb-6'>
          <label
            htmlFor='confirmPassword'
            className='block mb-2 text-sm font-medium text-gray-700 dark:text-gray-400'
          >
            Confirmar Contraseña
          </label>
          <input
            type='password'
            id='confirmPassword'
            placeholder='********'
            {...register('confirmPassword')}
            className='w-full px-3 py-2 border border-gray-300 rounded-md dark:bg-gray-900 dark:text-white dark:border-gray-600 focus:outline-none focus:ring-blue-500 focus:border-blue-500'
            required
          />
          {errors.confirmPassword && (
            <p className='text-red-500'>{errors.confirmPassword.message}</p>
          )}
        </div>
        <Link
          to='/login'
          className='hover:underline dark:text-blue-400 text-base'
        >
          Ya tengo cuenta
        </Link>
        <button
          type='submit'
          className='w-full px-4 mt-2 py-2 text-sm font-medium text-white bg-blue-500 rounded-md hover:bg-blue-600 focus:outline-none focus-bg-blue-600'
        >
          Register
        </button>
      </form>
    </div>
  );
};

export default Register;
