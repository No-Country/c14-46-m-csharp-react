import { zodResolver } from '@hookform/resolvers/zod';
import React from 'react';
import { useForm } from 'react-hook-form';
import { Link } from 'react-router-dom';
import { z, ZodType } from 'zod';

type FormData = {
  email: string;
  password: string;
};

const Login = () => {
  const schema: ZodType<FormData> = z.object({
    email: z.string().email({ message: 'Dirección de correo inválida' }),
    password: z.string(),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });

  const submitData = (data: FormData) => {
    console.log('Working...', data);
  };
  return (
    <div className='min-h-screen flex items-center justify-center bg-gray-600 px-6'>
      <div className='max-w-md w-full bg-white p-6 rounded-lg shadow-lg'>
        <form onSubmit={handleSubmit(submitData)}>
          <div className='mb-4'>
            <label className='block text-xl text-gray-900'>Email</label>
            <input
              className='input input-bordered input-sm w-full'
              type='email'
              {...register('email')}
              placeholder='Email...'
            />
            {errors.email && (
              <span className='text-red-600'>{errors.email.message}</span>
            )}
          </div>
          <div className='mb-4'>
            <label className='block text-xl text-gray-900'>Password</label>
            <input
              className='input input-bordered input-sm w-full'
              type='password'
              {...register('password')}
              placeholder='Contraseña...'
            />
            {errors.password && (
              <span className='text-red-600'>{errors.password.message}</span>
            )}
          </div>
          <a href='/register' className='text-blue-800'>
            Olvidé mi contraseña
          </a>
          <br />
          <Link to='/register' className='text-blue-800'>
            Crear Cuenta
          </Link>
          <button
            type='submit'
            className='btn btn-active btn-secondary w-full mt-5'
          >
            Iniciar Sesión
          </button>
        </form>
      </div>
    </div>
  );
};

export default Login;
