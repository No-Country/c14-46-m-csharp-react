import { zodResolver } from '@hookform/resolvers/zod';
import React, { useEffect } from 'react';
import { useForm } from 'react-hook-form';
import { useDispatch } from 'react-redux';
import { Link, useNavigate } from 'react-router-dom';
import { z, ZodType } from 'zod';
import { getUsers } from '../../services/apiPizza';
import toast from 'react-hot-toast';
import { updateUser } from '../user/userSlice';

type FormData = {
  email: string;
  password: string;
};

const Login = () => {
  const [users, setUsers] = React.useState([]);
  const navigate = useNavigate();
  const dispatch = useDispatch();

  useEffect(() => {
    getUsers().then((data) => {
      setUsers(data);
    });
  }, []);

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
    const loggedUser = users.find((user) => user.email === data.email);

    if (
      data.email === loggedUser?.email &&
      data.password === loggedUser?.password
    ) {
      toast.success('Logueado con exito');
      dispatch(updateUser(loggedUser));
      navigate('/menu');
    } else {
      toast.error('Email o contraseña incorrectos');
    }
  };
  return (
    <div className='flex items-center justify-center h-screen'>
      <div className='flex flex-col max-w-md p-6 rounded-md sm:p-10 dark:bg-gray-900 dark:text-gray-100'>
        <div className='mb-8 text-center'>
          <h1 className='my-3 text-4xl font-bold'>Iniciar Sesión</h1>
          <p className='text-sm dark:text-gray-400'>
            Inicia sesión para acceder a tu cuenta
          </p>
        </div>
        <form onSubmit={handleSubmit(submitData)} className='space-y-12'>
          <div className='space-y-4'>
            <div>
              <label htmlFor='email' className='block mb-2 text-sm'>
                Correo Electrónico
              </label>
              <input
                type='email'
                {...register('email')}
                id='email'
                placeholder='leroy@jenkins.com'
                className='w-full px-3 py-2 border rounded-md dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100'
              />
              {errors.email && (
                <span className='text-red-600'>{errors.email.message}</span>
              )}
            </div>
            <div>
              <div className='flex justify-between mb-2'>
                <label htmlFor='password' className='text-sm'>
                  Contraseña
                </label>
                <Link
                  to='/forgotPassword'
                  className='text-xs hover:underline dark:text-gray-400'
                >
                  Olvidé Mi Contraseña
                </Link>
              </div>
              <input
                type='password'
                {...register('password')}
                id='password'
                placeholder='*********'
                className='w-full px-3 py-2 border rounded-md dark:border-gray-700 dark:bg-gray-900 dark:text-gray-100'
              />
              {errors.password && (
                <span className='text-red-600'>{errors.password.message}</span>
              )}
            </div>
          </div>
          <div className='space-y-2'>
            <div>
              <button
                type='submit'
                className='w-full px-8 py-3 font-semibold rounded-md dark:bg-violet-400 dark:text-gray-900'
              >
                Iniciar Sesión
              </button>
            </div>
            <p className='px-6 text-sm text-center dark:text-gray-400'>
              Todavía No Tienes Una Cuenta?
              <Link to='/register' className='text-blue-600 font-bold'>
                {' '}
                Crear Cuenta
              </Link>
              .
            </p>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;
