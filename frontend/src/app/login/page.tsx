'use client';

import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import { signIn } from 'next-auth/react';
import { FormEvent, FormEventHandler, useState } from 'react';
import { useToast } from '@/components/ui/use-toast';
import { Loader } from 'lucide-react';

export default function Login() {
  const { toast } = useToast();
  const [userInfo, setUserInfo] = useState({ username: '', password: '' });
  const [isLoading, setIsLoading] = useState(false);

  const handleLogin = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setIsLoading(true);

    try {
      const res = await signIn('credentials', {
        username: userInfo.username,
        password: userInfo.password,
        redirect: false,
      });

      if (res?.ok) {
        setUserInfo({ username: '', password: '' });
        toast({ description: 'Logged in successfully' });
      } else {
        toast({ description: `${res?.error}` });
      }
    } catch (err: any) {
      console.log(err);
      toast({ description: err.toString() });
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <main className="flex flex-col items-center justify-center gap-5 h-full">
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
          required
        />
        <Input
          type="password"
          placeholder="Password"
          name="password"
          value={userInfo.password}
          onChange={({ target }) =>
            setUserInfo({ ...userInfo, password: target.value })
          }
          required
        />
        {isLoading ? (
          <Button
            disabled
            className="w-full"
          >
            <Loader className="mr-2 h-4 w-4 animate-spin" />
            Loggin in
          </Button>
        ) : (
          <Button type="submit">Log In</Button>
        )}
      </form>
    </main>
  );
}
