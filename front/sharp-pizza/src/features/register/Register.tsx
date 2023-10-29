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
        .email({ message: 'Dirección de correo invalida' })
        .min(6, {
          message: 'El correo debe tener al menos 6 caracteres',
        }),
      phoneNumber: z
        .string()
        .refine((value) => value.replace(/\D/g, '').length > 9, {
          message: 'Ingrese un número de telefono válido',
        }),
      address: z.string().min(6, { message: 'La dirección debe tener al menos 6 caracteres' }),
      password: z
        .string()
        .min(6, { message: 'La contraseña debe tener al menos 6 caracteres' }),
      confirmPassword: z
        .string()
        .min(6, { message: 'La contraseña debe tener al menos 6 caracteres' }),
    })
    .refine((data) => data.password === data.confirmPassword, {
      message: 'Las contraseñas no coinciden',
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
    toast.promise(axios.post('https://sharp-pizza-api.onrender.com/users', {
      name: data.fullName,
      password: data.password,
      phone: data.phoneNumber,
      email: data.email,
      address: data.address
    }).then(() => {
      navigate('/login')
    }), {
    loading: 'Registrando...',
    success: 'Registrado con exito 🍕️',
    error: 'Error en proceso de registro. Por favor intente mas tarde.',
    })
  };
  return (
    <div className='min-h-screen flex items-center justify-center bg-stone-100'>

      <form
        className='bg-lime-200 shadow-2xl rounded-lg px-8 pt-6 pb-2 mb-1 w-full max-w-md'
        onSubmit={handleSubmit(submitData)}
      >
        <div className='mb-4'>
          <label className='block text-xl text-slate-900'>Nombre Completo</label>
          <input
            id='fullName'
            className='input input-bordered input-sm w-full'
            type='text'
            {...register('fullName')}
            placeholder='Nombre Completo...'
          />
          {errors.fullName && (
            <span className='text-red-600'>{errors.fullName.message}</span>
          )}
        </div>
        <div className='mb-4'>
          <label className='block text-xl text-slate-900'>Email</label>
          <input
            id='email'
            className='input input-success input-sm w-full'
            type='email'
            {...register('email')}
            placeholder='Email...'
          />
          {errors.email && (
            <span className='text-red-600'>{errors.email.message}</span>
          )}
        </div>
        <div className='mb-4'>
          <label className='block text-xl text-slate-900'>
            Número de teléfono
          </label>
          <input
            id='phoneNumber'
            className='input input-success input-sm w-full'
            type='text'
            {...register('phoneNumber')}
            placeholder='Número de teléfono...'
          />
          {errors.phoneNumber && (
            <span className='text-red-600'>{errors.phoneNumber.message}</span>
          )}
        </div>

        <div className='mb-4'>
          <label className='block text-xl text-slate-900'>
            Domicilio
          </label>
          <input
            id='address'
            className='input input-success input-sm w-full'
            type='text'
            {...register('address')}
            placeholder='Domicilio...'
          />
          {errors.address && (
            <span className='text-red-600'>{errors.address.message}</span>
          )}
        </div>


        <div className='mb-4'>
          <label className='block text-xl text-slate-900'>Contraseña</label>
          <input
            className='input input-success input-sm w-full'
            type='password'
            {...register('password')}
            placeholder='Password...'
          />
          {errors.password && (
            <span className='text-red-600'>{errors.password.message}</span>
          )}
        </div>
        <div className='mb-4'>
          <label className='block text-xl text-slate-900'>
            Confirmar Contraseña
          </label>
          <input
            className='input input-success input-sm w-full'
            id='confirmPassword'
            type='password'
            {...register('confirmPassword')}
            placeholder='Confirm Password...'
          />
          {errors.confirmPassword && (
            <span className='text-red-600'>
              {errors.confirmPassword.message}
            </span>
          )}
        </div>
        <Link to='/login' className='text-blue-800 font-bold'>
          Ya tengo una cuenta
        </Link>
        <button
          type='submit'
          className='btn btn-active btn-primary btn-sm w-full mt-5'
        >
          Registrarme
        </button>
      </form>

      
    </div>
  );
};

export default Register;
