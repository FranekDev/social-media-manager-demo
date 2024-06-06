'use client';

import { Loader } from 'lucide-react';
import { Button } from '../ui/button';
import { Input } from '../ui/input';
import { useToast } from '../ui/use-toast';
import { FormEvent, useEffect, useState } from 'react';
import { ConfigProvider, TimePicker, theme } from 'antd';
import { Dayjs } from 'dayjs';
import type { DatePickerProps } from 'antd';
import { DatePicker, Space } from 'antd';
import useUserDetails from '@/lib/hooks/useUserDetails';
import Image from 'next/image';
import { Textarea } from '@/components/ui/textarea';
import { Label } from '../ui/label';
import { useSession } from 'next-auth/react';

export default function InstagramPostForm() {
  const { toast } = useToast();
  const [postData, setPostData] = useState({ caption: '', imageUrl: '' });
  const [isLoading, setIsLoading] = useState(false);
  const [result, setResult] = useState({});

  const format = 'HH:mm';

  const [time, setTime] = useState<Dayjs>();
  const [date, setDate] = useState<Dayjs>();
  const userDetails = useUserDetails();

  useEffect(() => {
    console.log(postData.caption);
  }, [postData]);

  const { data: session } = useSession();

  const onChange: DatePickerProps['onChange'] = (date, dateString) => {
    setDate(date);
  };

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setIsLoading(true);

    try {
      const publishTime = time?.toISOString().split('T')[1];
      const publishDate = date?.toISOString().split('T')[0];

      const result = await fetch(
        'https://localhost:7112/api/instagramcontent/publish',
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            ...postData,
            publishTime,
            publishDate,
            igUserId: userDetails?.id,
            userEmail: session?.user?.email,
          }),
        }
      );
      setResult(result);
      toast({ description: 'Post scheduled' });
      console.log(
        JSON.stringify({
          ...postData,
          publishTime,
          publishDate,
          igUserId: userDetails?.id,
          userEmail: session?.user?.email,
        })
      );

      setPostData({ caption: '', imageUrl: '' });
      setTime(undefined);
      setDate(undefined);

    } catch (err: any) {
      console.error(err);
      toast({ description: err.toString() });
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="flex w-full justify-center items-center gap-8">
      <form
        action=""
        className="w-fit flex flex-col gap-4 justify-center items-center"
        onSubmit={handleSubmit}
      >
        <div className="flex flex-col gap-3">
          <Label
            htmlFor="caption"
            className="ml-1"
          >
            Caption
          </Label>
          <Textarea
            placeholder="Caption"
            id="caption"
            className="w-96"
            value={postData.caption}
            onChange={({ target }) =>
              setPostData({ ...postData, caption: target.value })
            }
            required
          />
        </div>

        <div className="flex flex-col gap-3 w-full">
          <Label
            htmlFor="imageUrl"
            className="ml-1"
          >
            Image link
          </Label>
          <Input
            type="text"
            id="imageUrl"
            placeholder="Image link"
            className="w-full"
            value={postData.imageUrl}
            onChange={({ target }) =>
              setPostData({ ...postData, imageUrl: target.value })
            }
            required
          />
        </div>

        <div className="flex flex-col gap-3 w-full">
          <Label className="ml-1">Publication date</Label>
          <ConfigProvider
            theme={{
              algorithm: theme.darkAlgorithm,
            }}
          >
            <div className="flex gap-4 w-full">
              <DatePicker
                onChange={onChange}
                value={date}
                className="w-full"
                required
              />
              <TimePicker
                format={format}
                value={time}
                onChange={(value: Dayjs) => {
                  setTime(value);
                }}
                className="w-full"
                required
              />
            </div>
          </ConfigProvider>
        </div>

        {isLoading ? (
          <Button
            disabled
            className="w-full"
          >
            <Loader className="mr-2 h-4 w-4 animate-spin" />
            Publishing
          </Button>
        ) : (
          <Button
            type="submit"
            className="w-full"
          >
            Schedule post
          </Button>
        )}
      </form>
      <div className="flex flex-col gap-4 h-full max-w-[310px]">
        {postData.caption.length > 0 && (
          <>
            <Image
              src={postData.imageUrl ?? ''}
              alt="Image preview"
              width={300}
              height={600}
              className="rounded"
            />
            <div className='max-h-48 overflow-y-auto'>
              {postData.caption.split('\n').map((item) => {
                return (<span key={item.length}>
                  {item}
                  <br />
                </span>);
              })}
            </div>
          </>
        )}
      </div>
    </div>
  );
}
