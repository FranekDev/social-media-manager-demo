import { Button } from '@/components/ui/button';
import Link from 'next/link';

export default function Home() {
  return (
    <div className='flex flex-col justify-center items-center w-screen h-screen'>
      <h1>Social Media Manager</h1>
      <Button variant='link'>
        <Link  href="/login">IG Login</Link>
      </Button>
    </div>
  );
}

