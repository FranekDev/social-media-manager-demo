'use client';

import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import { signIn } from 'next-auth/react';
import { FormEvent, FormEventHandler, useState } from 'react';
import { useToast } from '@/components/ui/use-toast';

export default function Login() {
  const { toast } = useToast();
  const [userInfo, setUserInfo] = useState({ username: '', password: '' });

  const handleLogin = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const res = await signIn('credentials', {
      username: userInfo.username,
      password: userInfo.password,
      redirect: false,
    });
    setUserInfo({ username: '', password: '' });
    toast({ description: 'Logged in successfully' });
  };

  return (
    <main className="flex flex-col items-center justify-center gap-5 h-screen">
      <form
        onSubmit={handleLogin}
        className="flex flex-col gap-2"
      >
        <Input
          type="text"
          placeholder="Login"
          name="username"
          value={userInfo.username}
          onChange={({ target }) =>
            setUserInfo({ ...userInfo, username: target.value })
          }
        />
        <Input
          type="password"
          placeholder="Password"
          name="password"
          value={userInfo.password}
          onChange={({ target }) =>
            setUserInfo({ ...userInfo, password: target.value })
          }
        />
        <Button type="submit">
          Log In
        </Button>
      </form>
    </main>
  );
}
